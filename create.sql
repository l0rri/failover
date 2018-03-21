CREATE TABLE Business (
	business_id VARCHAR(24) PRIMARY KEY,
	name VARCHAR(22) NOT NULL,
	address VARCHAR(32),
	city VARCHAR(24),
	state VARCHAR(2),
	postal_code VARCHAR(5),
	is_Open BOOL,
	stars DECIMAL,
	review_count INTEGER

)

CREATE TABLE Checkin (
	business_id VARCHAR(22),
	
	FOREIGN KEY business_id REFERENCES 
		Business(business_id)
)

CREATE TABLE User (
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
	cool INTEGER
	
	FOREIGN KEY business_id REFERENCES
		Business(business_id),
	FOREIGN KEY user_id REFERENCES 
		User(user_id)
	
)
