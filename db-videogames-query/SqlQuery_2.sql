SELECT COUNT(*)
FROM software_houses
GROUP BY software_houses.country

SELECT videogames.id, COUNT(*) as reviews
FROM videogames
JOIN reviews ON videogames.id = reviews.videogame_id
GROUP BY videogames.id;

SELECT pegi_labels.id,
COUNT(*) AS n_videogames
FROM pegi_label_videogame
GROUP BY pegi_label_id;


SELECT release_date, COUNT(*) AS videogames
FROM videogames
GROUP BY year; 

SELECT device_id,
COUNT(*) as n_videogames
FROM device_videogame
GROUP BY device_id;

SELECT videogames_id, AVG(rating) as rating
FROM reviews
GROUP BY videogame_id
ORDER BY rating DESC; 
