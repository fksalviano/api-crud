CREATE TABLE WeatherForecast
(
    Id VARCHAR PRIMARY KEY,
    Date DATETIME NOT NULL,
    TemperatureC INT NOT NULL,
    Summary VARCHAR(100)
);

INSERT INTO WeatherForecast values ('1ae71318-fa78-428d-b4f6-436e6753f27c', DATE('now'), 20, 'Cool');
INSERT INTO WeatherForecast values ('3293bf99-dad1-4bc1-916c-43b60a2dbf58', DATE('now'), 8, 'Freezing');
INSERT INTO WeatherForecast values ('2ef77ddb-0a1b-4940-97c8-79a81613832e', DATE('now'), 25, 'Bracing');
INSERT INTO WeatherForecast values ('c46bb531-f815-4902-bb6a-e26dbed9d51a', DATE('now'), 29, 'Chilly');
INSERT INTO WeatherForecast values ('d8ccbacd-ff80-42f5-9ec9-dbc2ca2c3cc0', DATE('now'), 32, 'Warm');
