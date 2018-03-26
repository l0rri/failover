/* 
	IT Crowd Triggers
*/

CREATE OR REPLACE FUNCTION updateReviewRatingsAndCounts() RETURNS TRIGGER AS $$
	DECLARE
		oldrowcount INTEGER;
		newrowcount INTEGER;
		oldBID VARCHAR(22);
		newBID VARCHAR(22);
		ratingdelta INTEGER;
		countdelta INTEGER;
	BEGIN	
		CASE 
			WHEN (TG_OP = 'DELETE') THEN
				SELECT COUNT(DISTINCT business_id) INTO oldrowcount FROM oldtable;
				SELECT business_id INTO oldBID FROM oldtable;
				newrowcount := 0;
			WHEN (TG_OP = 'INSERT') THEN
				SELECT COUNT(DISTINCT business_id) INTO newrowcount FROM newtable;
				SELECT business_id INTO newBID FROM newtable;
				oldrowcount := 0;
			WHEN (TG_OP = 'UPDATE') THEN
				SELECT COUNT(DISTINCT business_id) INTO oldrowcount FROM oldtable;
				SELECT COUNT(DISTINCT business_id) INTO newrowcount FROM newtable;
				SELECT business_id INTO newBID FROM newtable;
				SELECT business_id INTO oldBID FROM oldtable;				
		END CASE;
		IF (oldrowcount IN (0, 1) AND newrowcount IN (0, 1)) THEN
			--RAISE NOTICE 'Using single-row optimizations';
			CASE
				WHEN (TG_OP = 'DELETE') THEN
					SELECT SUM(stars) * -1 INTO ratingdelta FROM oldtable;
					SELECT COUNT(*) * -1 INTO countdelta FROM oldtable;
				WHEN (TG_OP = 'UPDATE') THEN
					SELECT SUM(oldtable.stars) - SUM(newtable.stars) INTO ratingdelta FROM oldtable,newtable;
					countdelta := 0;
				WHEN (TG_OP = 'INSERT') THEN
					SELECT SUM(stars) INTO ratingdelta FROM newtable;
					SELECT COUNT(*) INTO countdelta FROM newtable;
			END CASE;
			UPDATE yelp_business
				SET 
					reviewrating = ((reviewrating * review_count) + ratingdelta) / (review_count + countdelta),
					review_count = review_count + countdelta
				WHERE (
					yelp_business.business_id = COALESCE(newBID, oldBID)
				)
			;
		ELSE
			--RAISE NOTICE 'Using multi-row subquery logic';
			WITH sq AS (
				SELECT 
					business_id,
					AVG(stars) AS newreviewrating,
					COUNT(*) AS newreviewcount
				FROM
					yelp_review
				GROUP BY
					business_id
			)
			UPDATE yelp_business
				SET 
					reviewrating = sq.newreviewrating,
					review_count = sq.newreviewcount
				FROM
					sq
				WHERE (
					sq.business_id = yelp_business.business_id AND 
					yelp_business.reviewrating != sq.newreviewrating OR
					yelp_business.review_count != sq.newreviewcount
				)
			;
		END IF;
		RETURN NULL;
	END
$$ LANGUAGE plpgsql;

CREATE TRIGGER RatingsAndCounts_insert
AFTER INSERT ON yelp_review
REFERENCING NEW TABLE AS newtable
FOR EACH STATEMENT
EXECUTE PROCEDURE updateReviewRatingsAndCounts();

CREATE TRIGGER RatingsAndCounts_update
AFTER UPDATE ON yelp_review
REFERENCING OLD TABLE AS oldtable NEW TABLE AS newtable
FOR EACH STATEMENT
EXECUTE PROCEDURE updateReviewRatingsAndCounts();

CREATE TRIGGER RatingsAndCounts_delete
AFTER DELETE ON yelp_review
REFERENCING OLD TABLE AS oldtable
FOR EACH STATEMENT
EXECUTE PROCEDURE updateReviewRatingsAndCounts();
		
CREATE OR REPLACE FUNCTION updateCheckinCount() RETURNS TRIGGER AS $$
	DECLARE
		oldrowcount INTEGER;
		newrowcount INTEGER;
		oldBID VARCHAR(22);
		newBID VARCHAR(22);
		checkindelta INTEGER;
	BEGIN
		CASE 
			WHEN (TG_OP = 'DELETE') THEN
				SELECT COUNT(DISTINCT business_id) INTO oldrowcount FROM oldtable;
				SELECT business_id INTO oldBID FROM oldtable;
				newrowcount := 0;
			WHEN (TG_OP = 'INSERT') THEN
				SELECT COUNT(DISTINCT business_id) INTO newrowcount FROM newtable;
				SELECT business_id INTO newBID FROM newtable;
				oldrowcount := 0;
			WHEN (TG_OP = 'UPDATE') THEN
				SELECT COUNT(DISTINCT business_id) INTO oldrowcount FROM oldtable;
				SELECT COUNT(DISTINCT business_id) INTO newrowcount FROM newtable;
				SELECT business_id INTO newBID FROM newtable;
				SELECT business_id INTO oldBID FROM oldtable;				
		END CASE;
		IF (oldrowcount IN (0, 1) AND newrowcount IN (0, 1)) THEN
			--RAISE NOTICE 'Using single-row optimizations';
			CASE
				WHEN (TG_OP = 'DELETE') THEN
					SELECT SUM(
						morning + 
						afternoon + 
						evening + 
						night
					) * -1 INTO checkindelta FROM oldtable;
				WHEN (TG_OP = 'UPDATE') THEN
					SELECT SUM(
						oldtable.morning + 
						oldtable.afternoon + 
						oldtable.evening + 
						oldtable.night
					) - SUM(
						newtable.morning + 
						newtable.afternoon + 
						newtable.evening + 
						newtable.night
					) INTO checkindelta FROM oldtable,newtable;
				WHEN (TG_OP = 'INSERT') THEN
					SELECT SUM(
						morning + 
						afternoon + 
						evening + 
						night
					) INTO checkindelta FROM newtable;
			END CASE;
			UPDATE yelp_business
				SET 
					numcheckins = numcheckins + checkindelta
				WHERE (
					yelp_business.business_id = COALESCE(newBID, oldBID)
				)
			;
		ELSE
			--RAISE NOTICE 'Using multi-row subquery logic';
			WITH sq AS (
				SELECT 
					business_id,
					SUM(morning + afternoon + evening + night) AS newcheckincount
				FROM
					yelp_checkin
				GROUP BY
					business_id
			)
			UPDATE yelp_business
				SET 
					numCheckins = sq.newcheckincount
				FROM
					sq
				WHERE (
					sq.business_id = yelp_business.business_id
				)
			;
		END IF;
		RETURN NULL;
	END
$$ LANGUAGE plpgsql;

CREATE TRIGGER CheckinCount_delete
AFTER DELETE ON yelp_checkin
REFERENCING OLD TABLE AS oldtable
FOR EACH STATEMENT
EXECUTE PROCEDURE updateCheckinCount();

CREATE TRIGGER CheckinCount_update
AFTER UPDATE ON yelp_checkin
REFERENCING OLD TABLE AS oldtable NEW TABLE AS newtable
FOR EACH STATEMENT
EXECUTE PROCEDURE updateCheckinCount();

CREATE TRIGGER CheckinCount_insert
AFTER INSERT ON yelp_checkin
REFERENCING NEW TABLE AS newtable
FOR EACH STATEMENT
EXECUTE PROCEDURE updateCheckinCount();


/* Test trigger statements */
/*
SET datestyle=ymd;
INSERT INTO yelp_business 
	VALUES(1234567,'Tester', '1234 1st st', 'Pullman', 'WA', '99163', true, 0,0,0,0,0,0,0);
INSERT INTO yelp_user(user_id)
	VALUES (9876);
INSERT INTO yelp_checkin (business_id,day_of_week, morning, afternoon, evening, night)
	VALUES (1234567,'Monday', 0,0,0,1);
INSERT INTO yelp_review
	VALUES (1234567, 54321, 9876, 5, '2018-03-22','Great experience!',1,1,1);
INSERT INTO yelp_review
	VALUES (1234567, 54322, 9876, 1, '2018-03-22','Meh :(',1,1,1);
SELECT * FROM yelp_business;
*/
/* Results: reviewcount=2,stars=6,reveiwrating=3.0,numcheckins=2 */






		