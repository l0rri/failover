CREATE TABLE yelp_business (
	business_id VARCHAR(24) PRIMARY KEY,
	name VARCHAR(22) NOT NULL,
	address VARCHAR(32),
	city VARCHAR(24),
	state VARCHAR(2),
	postal_code VARCHAR(5),
	is_Open BOOL,
	stars DECIMAL,
	review_count INTEGER
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
	
		Meal type:
			Breakfast, brunch, lunch, dinner, dessert, late night
	
		Price
			level 1,2,3,4
	
	*/
)

/* Table excludes attributes listed as a sublist - GoodForMeal & categories */
CREATE TABLE yelp_attributes (
	business_id VARCHAR(22),
	attribute_name VARCHAR(22),
	attribute_value BOOLEAN,
	PRIMARY KEY (business_id, attribute_name),
	FOREIGN KEY (business_id) REFERENCES Business(business_id)
)

/* Table to include meal type attributes */
CREATE TABLE yelp_mealattributes (
	business_id VARCHAR(22),
	category_name VARCHAR(22), -- should always be "GoodForMeal"
	attribute_name VARCHAR(22),
	atribute_value BOOLEAN,
	PRIMARY KEY (business_id, category_name, attribute_name),
	FOREIGN KEY (business_id) REFERENCES Business(business_id),
	FOREIGN KEY (category_name) REFERENCES Attributes(attribute_name)
	
)

/* Table to include categories attributes */
CREATE TABLE yelp_categories (
	business_id VARCHAR(22),
	category_name VARCHAR(22), -- should always be "categories"
	atribute_value VARCHAR(22),
	PRIMARY KEY (business_id, category_name, attribute_value),
	FOREIGN KEY (business_id) REFERENCES Business(business_id),
	FOREIGN KEY (category_name) REFERENCES Attributes(attribute_name)
	
)

CREATE TABLE yelp_checkin ( 
	business_id VARCHAR(22),
	
	FOREIGN KEY business_id REFERENCES 
		Business(business_id)
	
	-- rest not used until milestone 3
)

CREATE TABLE yelp_user (
	average_stars DECIMAL,
	cool INTEGER,
	funny INTEGER,
	useful INTEGER,
	fans INTEGER,
	review_count INTEGER,
	name VARCHAR(22), 
	user_id(22) PRIMARY KEY,
	yelping_since DATE
	-- Missing list of friends
)


CREATE TABLE Review (
	business_id VARHCAR(22),
	review_id VARHCAR(22),
	user_id VARHCAR(22),
	stars INTEGER,
	date DATE,
	text LONGTEXT,
	useful INTEGER,
	funny INTEGER,
	cool INTEGER,
	
	FOREIGN KEY business_id REFERENCES
		Business(business_id),
	FOREIGN KEY user_id REFERENCES 
		User(user_id)
	
)
