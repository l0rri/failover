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
				SELECT COUNT(*) INTO oldrowcount FROM oldtable;
				SELECT business_id INTO oldBID FROM oldtable;
				newrowcount := 0;
			WHEN (TG_OP = 'INSERT') THEN
				SELECT COUNT(*) INTO newrowcount FROM newtable;
				SELECT business_id INTO newBID FROM newtable;
				oldrowcount := 0;
			WHEN (TG_OP = 'UPDATE') THEN
				SELECT COUNT(*) INTO oldrowcount FROM oldtable;
				SELECT COUNT(*) INTO newrowcount FROM newtable;
				SELECT business_id INTO newBID FROM newtable;
				SELECT business_id INTO oldBID FROM oldtable;				
		END CASE;
		IF (oldrowcount IN (0, 1) AND newrowcount IN (0, 1)) THEN
			RAISE NOTICE 'Using single-row optimizations';
			CASE
				WHEN (TG_OP = 'DELETE') THEN
					SELECT stars * -1 INTO ratingdelta FROM oldtable;
					countdelta := -1;
				WHEN (TG_OP = 'UPDATE') THEN
					SELECT oldtable.stars - newtable.stars INTO ratingdelta FROM oldtable,newtable;
					countdelta := 0;
				WHEN (TG_OP = 'INSERT') THEN
					SELECT stars INTO ratingdelta FROM newtable;
					countdelta := 1;
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
		
	
CREATE OR REPLACE FUNCTION updateCheckinCount() RETURNS TRIGGER AS
'BEGIN
    UPDATE yelp_business
        SET numcheckins = numcheckins + NEW.afternoon + NEW.morning + NEW.night + NEW.evening
        WHERE NEW.business_id = yelp_business.business_id;
    RETURN NEW;
END' LANGUAGE plpgsql;

CREATE TRIGGER updateCheckinCount
AFTER INSERT OR UPDATE OR DELETE ON yelp_checkin
FOR EACH ROW
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






		