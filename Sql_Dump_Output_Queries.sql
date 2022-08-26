--- 1. Select users whose id is either 3,2 or 4

select * from [users] where id in(2,3,4)

 

--2.Count how many basic and premium listings each active user has

SELECT

   u.first_name, u.last_name

  , [basic]   = count(case when l.status=2 then 1 end)

  , premium = count(case when l.status=3 then 1 end)

  , Total = COUNT(l.status)

FROM

  [users] u

  LEFT JOIN [listings] l ON u.ID = l.user_id and u.status =2 and l.user_id is not null

GROUP BY

   l.user_id,u.first_name, u.last_name

 

 

   --. 3.Show the same count as before but only if they have at least ONE premium listing

SELECT

   u.first_name, u.last_name

  , [basic]   = count(case when l.status=2 then 1 end)

  , premium = count(case when l.status=3 then 1 end)

  --, Rejected = count(case when tasks.status='Rejected ' then 1 end)

  , Total = COUNT(l.status)

FROM

  [users] u

  LEFT JOIN [listings] l ON u.ID = l.user_id and u.status =2  and l.user_id is not null

GROUP BY

   l.user_id,u.first_name, u.last_name having count(case when l.status=3 then 1 end)<>0

 

 

   --4. How much revenue has each active vendor made in 2013

Select u.first_name, u.last_name

,SUM(ISNULL(r.price,0))  as Revenue , YEAR(r.created) [year]

from users u

LEFT JOIN listings l on l.[user_id] = u.id and u.status =2

LEFT JOIN clicks r on r.listing_id = l.ID

group by l.user_id,u.first_name, u.last_name,YEAR(r.created)

having  YEAR(r.created)=2013  and l.user_id is not null

 

 

 

--5. Insert a new click for listing id 3, at $4.00

Declare @clickId int

insert into clicks(listing_id,price,currency,created) values(3,4,'USD',getDate())

select IDENT_CURRENT('clicks') 

 

--6. Show listings that have not received a click in 2013

select * from listings where ID not in(

select listing_ID from clicks where year(created) = 2013)

 

--7. For each year show number of listings clicked and number of vendors who owned these listings

-- Please return at least: date, total_listings_clicked, total_vendors_affected

 

 

Select [year],SUM(total_listings_clicked) as total_listings_clicked,SUM(total_vendors_affected) as total_vendors_affected

From

(Select YEAR(c.created) [year], count(l.id)  as total_listings_clicked, (select count(*) from users where ID =l.user_id)  as total_vendors_affected

from clicks c

inner JOIN listings l on l.id = c.listing_id

inner JOIN users u on u.id = l.user_id and l.user_id is not null

group by YEAR(c.created),l.user_id) subQuery

group by [year]

 

 

--8. Return a comma separated string of listing names for all active vendors

 

 

SELECT u.first_name,u.last_name,

         STRING_AGG(l.name, ',') as Listings

    FROM users u

    left JOIN listings l ON l.User_ID = u.id where u.status=2  and l.user_id is not null

GROUP BY u.first_name,u.last_name

 

 

 

 

--select * from users  --'1=disabled; 2=enabled',

--select * from listings --COMMENT '2=basic; 3=premium',

--select * from clicks