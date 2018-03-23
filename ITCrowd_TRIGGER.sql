 
CREATE OR REPLACE FUNCTION updateCheckinCount() RETURNS TRIGGER AS
'BEGIN
    UPDATE yelp_business
        SET numcheckins = numcheckins + NEW.afternoon + NEW.morning + NEW.night + NEW.evening
        WHERE NEW.business_id = yelp_business.bid;
    RETURN NEW;
END' LANGUAGE plpgsql;

CREATE TRIGGER updateCheckinCount
AFTER INSERT ON yelp_checkin
FOR EACH ROW
EXECUTE PROCEDURE updateCheckinCount();

CREATE OR REPLACE FUNCTION updateReviewCount() RETURNS trigger AS
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

CREATE OR REPLACE FUNCTION updateRating() RETURNS trigger AS
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
		
		
		