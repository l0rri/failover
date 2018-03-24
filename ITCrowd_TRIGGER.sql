/* 
	IT Crowd Triggers
*/

CREATE OR REPLACE FUNCTION updateReviewCount() RETURNS TRIGGER AS
'BEGIN
    UPDATE yelp_business
        SET review_count = review_count + 1,
		stars = stars + NEW.stars
        WHERE NEW.business_id = yelp_business.business_id;
    RETURN NEW;
END' LANGUAGE plpgsql;

CREATE TRIGGER updateReviewCount
AFTER INSERT ON yelp_review
FOR EACH ROW
EXECUTE PROCEDURE updateReviewCount();

CREATE OR REPLACE FUNCTION updateRating() RETURNS TRIGGER AS
'BEGIN
    UPDATE yelp_business
        SET reviewrating = stars / review_count
        WHERE NEW.business_id = yelp_business.business_id AND OLD.review_count != NEW.review_count;
    RETURN NEW;
END' LANGUAGE plpgsql;

CREATE TRIGGER updateRating
AFTER UPDATE ON yelp_business
FOR EACH ROW
EXECUTE PROCEDURE updateRating();	
		
	
CREATE OR REPLACE FUNCTION updateCheckinCount() RETURNS TRIGGER AS
'BEGIN
    UPDATE yelp_business
        SET numcheckins = numcheckins + NEW.afternoon + NEW.morning + NEW.night + NEW.evening
        WHERE NEW.business_id = yelp_business.business_id;
    RETURN NEW;
END' LANGUAGE plpgsql;

CREATE TRIGGER updateCheckinCount
AFTER INSERT ON yelp_checkin
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






		