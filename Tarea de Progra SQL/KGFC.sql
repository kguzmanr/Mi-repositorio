create table jugador
(
id int,
nombre varchar(50),
edad int,
)

create table entrenador
(
id int primary key identity(1,1),
nombre varchar(50),
titulos varchar(150),
)

insert into jugador(id, nombre, edad) values(1, 'Kevin Chamorro', 25)
insert into jugador(id, nombre, edad) values(2, 'Mariano Torres', 36)

select id, nombre, edad from jugador
select nombre from jugador
select * from jugador where edad = 36

select * from jugador
select * from entrenador

delete jugador where id = 1

update jugador set edad = 25 where id=1
