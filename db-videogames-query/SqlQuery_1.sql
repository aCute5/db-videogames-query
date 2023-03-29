SELECT *
FROM software_houses
WHERE software_houses.country = 'United States'

SELECT *
FROM players
WHERE players.city = 'Rogahnland'

SELECT *
FROM reviews
WHERE reviews.player_id = 800

SELECT COUNT(*)
FROM tournaments
WHERE tournaments.year = 2015;

SELECT * 
FROM awards
WHERE awards.description LIKE '%facere%';

SELECT DISTINCT videogames.id.*
from videogames
JOIN category_videogame on category_videogame.videogame_id = videogame_id
JOIN categories on category_id = category_videogame.category_id
WHERE categories.name = 'FPS';

SELECT *