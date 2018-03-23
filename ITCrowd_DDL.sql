/*
DROP TABLE IF EXISTS yelp_business CASCADE;
DROP TABLE IF EXISTS yelp_checkin CASCADE;
DROP TABLE IF EXISTS yelp_review CASCADE;
DROP TABLE IF EXISTS yelp_business_attributes CASCADE;
DROP TABLE IF EXISTS yelp_ambience_attribset CASCADE;
DROP TABLE IF EXISTS yelp_bestnight_attribset CASCADE;
DROP TABLE IF EXISTS yelp_music_attribset CASCADE;
DROP TABLE IF EXISTS yelp_good_meals_attribset CASCADE;
DROP TABLE IF EXISTS yelp_dietary_restrictions_attribset CASCADE;
DROP TABLE IF EXISTS yelp_hair_specialization_attribset CASCADE;
DROP TABLE IF EXISTS yelp_parking_attribset CASCADE;
DROP TABLE IF EXISTS yelp_business_hours CASCADE;
DROP TABLE IF EXISTS yelp_friends CASCADE;
DROP TABLE IF EXISTS yelp_user CASCADE;
DROP TABLE IF EXISTS yelp_business_categories CASCADE;
*/


CREATE TABLE yelp_business (
	business_id VARCHAR(22) PRIMARY KEY,
	name VARCHAR(64) NOT NULL,
	address VARCHAR(80),
	city VARCHAR(24),
	state VARCHAR(2),
	postal_code VARCHAR(5),
	is_Open BOOLEAN,
	stars DECIMAL DEFAULT 0,
	review_count INTEGER,
	latitude FLOAT,
	longitude FLOAT,
	numCheckins INTEGER DEFAULT 0,
	totalRating DECIMAL DEFAULT 0,
	reviewRating DECIMAL DEFAULT 0
	
	
);


/* Table excludes attributes listed as a sublist - GoodForMeal & categories */
CREATE TABLE yelp_business_attributes (
	business_id VARCHAR(22),
	accepts_insurance BOOLEAN,
	ages_allowed VARCHAR(12),
	alcohol VARCHAR(12),
	bike_parking BOOLEAN,
	accepts_bitcoin BOOLEAN,
	accepts_creditcard BOOLEAN,
	by_appointment BOOLEAN,
	byob BOOLEAN,
	byob_corkage VARCHAR(12),
	caters BOOLEAN,
	coat_check BOOLEAN,
	corkage BOOLEAN,
	dogs_allowed BOOLEAN,
	drivethru BOOLEAN,
	good_for_dancing BOOLEAN,
	good_for_kids BOOLEAN,
	happy_hour BOOLEAN,
	has_tv BOOLEAN,
	noise_level VARCHAR(12),
	open_24hrs BOOLEAN,
	outdoor_seating BOOLEAN,
	restaurant_attire VARCHAR(12),
	restaurant_counter_service BOOLEAN,
	restaurant_delivery BOOLEAN,
	good_for_groups BOOLEAN,
	wheelchair_accessible BOOLEAN,
	pricerange2 INTEGER,
	has_reservations BOOLEAN,
	smoking VARCHAR(12),
	wifi VARCHAR(12),
	
	PRIMARY KEY (business_id),
	FOREIGN KEY (business_id) REFERENCES yelp_business(business_id)
);

CREATE TABLE yelp_ambience_attribset (
	business_id VARCHAR(22), 
	casual BOOLEAN,
	classy BOOLEAN,
	divey BOOLEAN,
	hipster BOOLEAN,
	intimate BOOLEAN,
	romantic BOOLEAN,
	touristy BOOLEAN,
	trendy BOOLEAN,
	upscale BOOLEAN,
	
	PRIMARY KEY(business_id),
	FOREIGN KEY (business_id) REFERENCES yelp_business(business_id)

);
CREATE TABLE yelp_bestnight_attribset (
	business_id VARCHAR(22), 
	sunday BOOLEAN,
	monday BOOLEAN,
	tuesday BOOLEAN,
	wednesday BOOLEAN,
	thursday BOOLEAN,
	friday BOOLEAN,
	saturday BOOLEAN,
	
	PRIMARY KEY(business_id),
	FOREIGN KEY (business_id) REFERENCES yelp_business(business_id)

);

CREATE TABLE yelp_music_attribset (
	business_id VARCHAR(22), 
	background BOOLEAN,
	dj BOOLEAN,
	jukebox BOOLEAN,
	karaoke BOOLEAN,
	live BOOLEAN,
	no_music BOOLEAN,
	video BOOLEAN,
	
	PRIMARY KEY(business_id),
	FOREIGN KEY (business_id) REFERENCES yelp_business(business_id)

);

CREATE TABLE yelp_dietary_restrictions_attribset (
	business_id VARCHAR(22), 
	dairy_free BOOLEAN,
	gluten_free BOOLEAN,
	halal BOOLEAN,
	kosher BOOLEAN,
	soy_free BOOLEAN,
	vegan BOOLEAN,
	vegetarian BOOLEAN,
	
	PRIMARY KEY(business_id),
	FOREIGN KEY (business_id) REFERENCES yelp_business(business_id)

);


CREATE TABLE yelp_good_meals_attribset (
	business_id VARCHAR(22), 
	breakfast BOOLEAN,
	brunch BOOLEAN,
	lunch BOOLEAN,
	dessert BOOLEAN,
	dinner BOOLEAN,
	latenight BOOLEAN,
	
	PRIMARY KEY(business_id),
	FOREIGN KEY (business_id) REFERENCES yelp_business(business_id)

);


CREATE TABLE yelp_hair_specialization_attribset (
	business_id VARCHAR(22), 
	african_american BOOLEAN,
	asian BOOLEAN,
	coloring BOOLEAN,
	curly BOOLEAN,
	extensions BOOLEAN,
	kids BOOLEAN,
	perms BOOLEAN,
	straight_perms BOOLEAN,
	
	PRIMARY KEY(business_id),
	FOREIGN KEY (business_id) REFERENCES yelp_business(business_id)

);


CREATE TABLE yelp_parking_attribset (
	business_id VARCHAR(22), 
	garage BOOLEAN,
	lot BOOLEAN,
	street BOOLEAN,
	valet BOOLEAN,
	validated BOOLEAN,
	
	PRIMARY KEY(business_id),
	FOREIGN KEY (business_id) REFERENCES yelp_business(business_id)

);


CREATE TABLE yelp_business_hours (
	day_of_week DATE,
	is_open BOOLEAN,
	business_id VARCHAR(22), 
	PRIMARY KEY(business_id, day_of_week),
	FOREIGN KEY(business_id) REFERENCES yelp_business(business_id)
	
	
);


/* Table to include categories attributes */
CREATE TABLE yelp_business_categories (
	business_id VARCHAR(22),
	category_name VARCHAR(22), 
	PRIMARY KEY (business_id, category_name),
	FOREIGN KEY (business_id) REFERENCES yelp_business(business_id)
	
);


CREATE TABLE yelp_user (
	fans INTEGER,
	review_count INTEGER,
	name VARCHAR(22), 
	user_id VARCHAR(22) PRIMARY KEY,
	yelping_since DATE
);


CREATE TABLE yelp_friends (
	user_id VARCHAR(22),
	friend_id VARCHAR(22),
	PRIMARY KEY (user_id, friend_id),
	FOREIGN KEY (user_id) REFERENCES yelp_user(user_id)
);


CREATE TABLE yelp_review (
	business_id VARCHAR(22),
	review_id VARCHAR(22),
	user_id VARCHAR(22),
	stars INTEGER,
	date DATE,
	text TEXT,
	useful INTEGER,
	funny INTEGER,
	cool INTEGER,
	PRIMARY KEY(review_id),
	FOREIGN KEY (business_id) REFERENCES yelp_business(business_id),
	FOREIGN KEY (user_id) REFERENCES yelp_user(user_id)
	
);


CREATE TABLE yelp_checkin (
	business_id VARCHAR(22),
	day_of_week DATE,
	morning INTEGER,
	afternoon INTEGER,
	evening INTEGER,
	night INTEGER,
	PRIMARY KEY(business_id, day_of_week),
	FOREIGN KEY (business_id) REFERENCES yelp_business(business_id)

);
