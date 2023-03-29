SELECT DISTINCT players.*
FROM players
INNER JOIN reviews ON players.id = reviews.player_id;

SELECT DISTINCT videogames.*
FROM videogames
INNER JOIN tournament_videogame ON videogames.id = tournament_videogame.videogame_id
INNER JOIN tournaments ON tournament_videogame.tournament_id = tournaments.id
WHERE YEAR(tournaments.year) = 2016;

SELECT videogames.name, categories.name
FROM videogames
INNER JOIN category_videogame ON videogames.id = category_videogame.videogame_id
INNER JOIN categories ON categories.id = category_videogame.category_id

SELECT DISTINCT software_houses.*
FROM software_houses
INNER JOIN videogames ON software_house_id = videogames.software_house_id
WHERE  YEAR(videogames.release_date) > 2020;

SELECT  software_houses.name, awards.name
FROM sotfware_houses
JOIN videogames ON software_house.id = videogames.software_house_id
JOIN award_videogame ON videogames.id = award_videogame.videogame_id
JOIN awards ON award_videogame.award_id = awards.id
GROUP BY software_houses.name, awards.name;

SELECT DISTINCT categories.name, pegi_labels.name
FROM categories
JOIN category_videogame ON categories.id = category_videogame.category_id
JOIN videogames ON category_videogame.videogame_id = videogames.id
JOIN reviews ON videogames.id = reviews.videogame_id
JOIN pegi_label_videogame ON videogames.id = pegi_label_videogame.videogame_id
JOIN pegi_labels ON pegi_label_videogame.pegi_label_id = pegi_label_id
WHERE reviews.rating IN (4,5);

SELECT DISTINCT tournaments.city
FROM videogames
JOIN award_videogame ON videogames.id = award_videogame.videogame_id
JOIN awards ON award_videogame.award_id = awards.id
JOIN tournament_videogame ON videogames.id = tournament_videogame.videogame_id
JOIN tournaments ON tournament_videogame.tournament_id = tournaments.id
WHERE awards.name = 'Gioco dell'' anno' AND award_videogame.year = 2018 AND tournaments.year = 2018;