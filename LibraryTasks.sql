/*
Написать следующие запросы, используя базу данных Library. 

Показать издательства и сумму страниц по каждому из них.
Показать общее кол-во книг, взятых студентами факультета 'Программирования'.
Вывести кол-во книг и сумму страниц этих книг по каждому из издательств 'Питер','Наука' и 'Кудиц-Образ'.
Вывести информацию о книге по программированию с наибольшим количеством страниц.
Вывести на экран кол-во взятых книг по каждой из кафедр.
Показать издательства и самую старую книгу для каждого из них.
Показать книги, которые брали и преподаватели и студенты (исключить повторения).
Показать название книги с максимальным кол-вом страниц по каждому из издательств.(с начала найти максимум по издательствам, после чего вложить этот запрос внутрь поиска по книгам)
*/

--Показать издательства и сумму страниц по каждому из них.
select Press.Name, sum(Books.Pages) as qty from Press
left join Books on Press.Id = Books.Id_Press
group by Press.name
having sum(Books.Pages) is not null

--Показать общее кол-во книг, взятых студентами факультета 'Программирования'.
	--select Students.Id from Faculties
	--left join Groups on Faculties.Id = Groups.Id_Faculty
	--left join Students on Students.Id_Group = Groups.Id
	--where Groups.Id_Faculty=1
select count(*) [кол-во книг] from S_Cards
WHERE Id_Student = ANY (select Students.Id from Groups left join Students on Students.Id_Group = Groups.Id where Groups.Id_Faculty=1)

--Вывести кол-во книг и сумму страниц этих книг по каждому из издательств 'Питер','Наука' и 'Кудиц-Образ'.
select Press.Name,count(Press.Id) [кол-во книг] ,SUM(Books.Pages) [сумму страниц]
from Press
left join Books on Books.Id_Press =press.id
where Press.name in('Питер','Наука','Кудиц-Образ')
group by Press.Name

--Вывести информацию о книге по программированию с наибольшим количеством страниц.
select top 1 Books.Name,Comment,YearPress from Books 
left join Themes on Themes.Id = Books.Id_Themes
where Themes.Name='Программирование'
order by Pages desc

--Вывести на экран кол-во взятых книг по каждой из кафедр.
select Faculties.Name,COUNT(id_book) [кол-во взятых]
From S_Cards
left join Students on Students.id = S_Cards.Id_Student
left join Groups on Groups.Id = Students.Id_Group
left join Faculties on Faculties.Id = Groups.Id_Faculty
Group by Faculties.Name

--Показать издательства и самую старую книгу для каждого из них.
Select Press.Name as PressName,Books.Name as BooksName,Query.Year
from(
	select Books.Id_Press, min(YearPress) as [Year]
	from Books
	Group By Books.Id_Press
	) as Query
Left join Press on Press.Id = Query.Id_Press
Left join Books on Books.YearPress = Query.Year and Books.Id_Press=Query.Id_Press

--Показать книги, которые брали и преподаватели и студенты (исключить повторения).
Select Books.name from Books
where Books.id = any
(
	Select Id_Book from S_Cards
	union 
	Select Id_Book From T_Cards
)

--Показать название книги с максимальным кол-вом страниц по каждому из издательств.
--(с начала найти максимум по издательствам, после чего вложить этот запрос внутрь поиска по книгам)

select name,Quantity from 
(
	Select Id_Press,max(Pages) as maxQuantity from Books
	group by Id_Press
) as qyery
Left join Books on Books.Pages = qyery.maxQuantity and Books.Id_Press=qyery.Id_Press

--Провкерка
--select * from Books
--Order by Id_Press,Quantity desc

