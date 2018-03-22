DROP TABLE yelp_business
CREATE TABLE yelp_business (
	business_id VARCHAR(22) PRIMARY KEY,
	name VARCHAR(22) NOT NULL,
	address VARCHAR(32),
	city VARCHAR(24),
	state VARCHAR(2),
	postal_code VARCHAR(5),
	is_Open BOOLEAN,
	stars DECIMAL,
	review_count INTEGER,
	latitude FLOAT,
	longitude FLOAT,
	numCheckins INTEGER,
	reviewRating DECIMAL
	
	-- still need list of attributes
	/*
	List of attributes to include:
		Accepts Credit Cards
		Takes Reservations
		Wheelchair Accessible
		Outdoor Seating
		Good for Kids	
		Good for Groups
		Delivery
		Take Out
		Free Wifi
		Bike Parking
		
		RestaurantPriceRange1
		RestaurantPriceRange2
		RestaurantPriceRange3
		RestaurantPriceRange4
	
		Meal type:
			Breakfast, brunch, lunch, dinner, dessert, late night
	
		Categories
			*whole bunch of stuff*
	
	*/
)


/* Table excludes attributes listed as a sublist - GoodForMeal & categories */
CREATE TABLE yelp_business_attributes (
	business_id VARCHAR(22),
	accepts_insurance BOOLEAN,
	ages_allowed BOOLEAN,
	alcohol BOOLEAN
	bike_parking BOOLEAN,
	accepts_bitcoin BOOLEAN,
	accepts_creditcard BOOLEAN,
	by_appointment BOOLEAN,
	byob BOOLEAN,
	byob_corkage BOOLEAN,
	caters BOOLEAN,
	coat_check BOOLEAN,
	corkage BOOLEAN,
	dogs_allowed BOOLEAN,
	drivethru BOOLEAN,
	good_for_dancing BOOLEAN,
	good_for_kids BOOLEAN,
	happy_hour BOOLEAN,
	has_tv BOOLEAN,
	noise_level BOOLEAN,
	open_24hrs BOOLEAN,
	outdoor_seating BOOLEAN,
	restaurant_attire BOOLEAN,
	restaurant_counter_service BOOLEAN,
	restaurant_delivery BOOLEAN,
	good_for_groups BOOLEAN,
	wheelchair_accessible BOOLEAN,
	pricerange1 BOOLEAN,
	pricerange2 BOOLEAN,
	pricerange3 BOOLEAN,
	pricerange4 BOOLEAN,
	has_reservations BOOLEAN,
	restaurant_delivery BOOLEAN,
	allows_smoking BOOLEAN,
	free_wifi BOOLEAN,
	
	PRIMARY KEY (business_id),
	FOREIGN KEY (business_id) REFERENCES yelp_business(business_id)
)

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

)

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

)

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

)

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

)

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

)

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

)

CREATE TABLE yelp_parking_attribset (
	business_id VARCHAR(22), 
	garage BOOLEAN,
	lot BOOLEAN,
	street BOOLEAN,
	valet BOOLEAN,
	validated BOOLEAN,
	
	PRIMARY KEY(business_id),
	FOREIGN KEY (business_id) REFERENCES yelp_business(business_id)

)

CREATE TABLE yelp_business_hours (
	day-of-week DATE,
	is_open BOOLEAN,
	business_id VARCHAR(22), 
	PRIMARY KEY(business_id, day-of-week),
	FOREIGN KEY(business_id) REFERENCES Business(business_id)
	
	
)
/* Table to include categories attributes */
CREATE TABLE yelp_business_categories (
	business_id VARCHAR(22),
	category_name VARCHAR(22), 
	PRIMARY KEY (business_id, category_name),
	FOREIGN KEY (business_id) REFERENCES yelp_business(business_id)
	
)


CREATE TABLE yelp_user (
	fans INTEGER,
	review_count INTEGER,
	name VARCHAR(22), 
	user_id VARCHAR(22) PRIMARY KEY,
	yelping_since DATE,
	-- friends with?
)

CREATE TABLE yelp_friends (
	user_id VARCHAR(22),
	friend_id VARCHAR(22),
	PRIMARY KEY (user_id, friend_id),
	FOREIGN KEY (user_id) REFERENCES yelp_user(user_id)
)

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
	
)

CREATE TABLE yelp_checkin (
	business_id VARCHAR(22),
	day-of-week DATE,
	morning INTEGER,
	afternoon INTEGER,
	evening INTEGER,
	night INTEGER,
	PRIMARY KEY(business_id, day-of-week),
	FOREIGN KEY (business_id) REFERENCES yelp_business(business_id)

)
