
-- Details
 CREATE TABLE details(
     detail_id SERIAL PRIMARY KEY,
     preferred_contact VARCHAR(255)
 );
 INSERT INTO details(preferred_contact)
 VALUES
 ('My name is austin and im a student a redwood'),
 ('I am a programmer');






 --Customers
 CREATE TABLE customers(
     customer_id SERIAL PRIMARY KEY,
     name VARCHAR(50),
     email VARCHAR(50),
     phone VARCHAR(50),
     age INT,
     detail_id INTEGER REFERENCES details(detail_id)
 );
 INSERT INTO customers(name,email,phone,age,detail_id)
 VALUES
 ('Austin English','englisha@uci.edu','949-201-5442',23,2),
 ('Dan English','dans@gmail.com','949-345-5678',40,1);








 -- status type
CREATE TABLE status_types(
     status_id SERIAL PRIMARY KEY,
     type VARCHAR(50)
     
 );
 INSERT INTO status_types(type)
 VALUES
 ('In Progress'),
 ('completed');









 -- priority type(one to one nothing needed here)
CREATE TABLE priority_types(
     priority_id SERIAL PRIMARY KEY,
     type VARCHAR(50)
     
 );
 INSERT INTO priority_types(type)
 VALUES
 ('Urgent'),
 ('At ones Convienence');






 -- employee type(need a list of leads here and list of interactions)
CREATE TABLE employees(
     employee_id SERIAL PRIMARY KEY,
     name VARCHAR(50),
     email VARCHAR(50),
     phone VARCHAR(50)
 );
 INSERT INTO employees(name,email,phone)
 VALUES
 ('Bob', 'bob1@gmail.com','951-678-9876'),
 ('Andrew', 'androo55@yahoo.com','956-668-7786');








-- lead type(need a priority type object here and a list of interactions)
CREATE TABLE leads(
     lead_id SERIAL PRIMARY KEY,
     last_contact TIMESTAMP,
     status_id INTEGER REFERENCES status_types(status_id),
     priority_id INTEGER REFERENCES priority_types(priority_id),
     customer_id INTEGER REFERENCES customers(customer_id),
     employee_id INTEGER REFERENCES employees(employee_id)
 );
--datetime format: YYYY-MM-DD HH:MI:SS
 INSERT INTO leads(last_contact,status_id,priority_id,customer_id,employee_id)
 VALUES
 ('2018-01-17 12:45:35',1,1,1,1),
 ('2018-01-17 3:15:17',2,2,2,2);







 -- interaction type(nothing needed here only manys coming in)
CREATE TABLE interactions(
     interaction_id SERIAL PRIMARY KEY,
     comment VARCHAR(255),
     date_time TIMESTAMP,
     duration INT,
     lead_id INTEGER REFERENCES leads(lead_id),
     employee_id INTEGER REFERENCES employees(employee_id)
 );
 INSERT INTO interactions(comment,date_time,duration,lead_id,employee_id)
 VALUES
 ('fixed your request','2018-01-18 12:45:35',15,1,1),
 ('updated your lead','2018-01-19 10:15:17',35,2,2);






