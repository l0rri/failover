CREATE OR REPLACE FUNCTION checkForOpenBusiness() RETURNS TRIGGER AS $$
	BEGIN
		IF ( (SELECT DISTINCT is_open FROM yelp_business 
				WHERE yelp_business.business_id = NEW.business_id ) = FALSE) THEN
			RAISE EXCEPTION 'Cannot add a review for a business that is closed.';
		END IF;
	
		RETURN NULL;
	END
$$ LANGUAGE plpgsql;

CREATE TRIGGER insertReview
BEFORE INSERT OR UPDATE ON yelp_review
FOR EACH ROW
EXECUTE PROCEDURE checkForOpenBusiness();

/* Test trigger statements */
/*
SET datestyle=ymd;
/* Test a valid review insert */ 
INSERT INTO yelp_business 
	VALUES(1234567,'Tester', '1234 1st st', 'Pullman', 'WA', '99163', true, 0,0,0,0,0,0);
INSERT INTO yelp_user(user_id)
	VALUES (9876);
INSERT INTO yelp_checkin (business_id,day_of_week, morning, afternoon, evening, night)
	VALUES (1234567,'Monday', 0,0,0,1);
INSERT INTO yelp_review
	VALUES (1234567, 54321, 9876, 5, '2018-03-22','Great experience!',1,1,1);
INSERT INTO yelp_review
	VALUES (1234567, 54322, 9876, 1, '2018-03-22','Meh :(',1,1,1);
	
/* Test an invalid insert - should fail is_open trigger */
	INSERT INTO yelp_business 
	VALUES('abcdefg','TestFail', '1234 1st st', 'Pullman', 'WA', '99163', false, 0,0,0,0,0,0);
INSERT INTO yelp_user(user_id)
	VALUES ('abcd');
INSERT INTO yelp_checkin (business_id,day_of_week, morning, afternoon, evening, night)
	VALUES ('abcdefg','Monday', 0,0,0,1);
INSERT INTO yelp_review
	VALUES ('abcdefg', 678987, 'abcd', 5, '2018-03-22','Great experience!',1,1,1);
INSERT INTO yelp_review
	VALUES ('abcdefg', 67898, 'abcd', 1, '2018-03-22','Meh :(',1,1,1);
SELECT * FROM yelp_business;
*/

