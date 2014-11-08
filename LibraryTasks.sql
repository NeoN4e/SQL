/*
�������� ��������� �������, ��������� ���� ������ Library. 

�������� ������������ � ����� ������� �� ������� �� ���.
�������� ����� ���-�� ����, ������ ���������� ���������� '����������������'.
������� ���-�� ���� � ����� ������� ���� ���� �� ������� �� ����������� '�����','�����' � '�����-�����'.
������� ���������� � ����� �� ���������������� � ���������� ����������� �������.
������� �� ����� ���-�� ������ ���� �� ������ �� ������.
�������� ������������ � ����� ������ ����� ��� ������� �� ���.
�������� �����, ������� ����� � ������������� � �������� (��������� ����������).
�������� �������� ����� � ������������ ���-��� ������� �� ������� �� �����������.(� ������ ����� �������� �� �������������, ����� ���� ������� ���� ������ ������ ������ �� ������)
*/

--�������� ������������ � ����� ������� �� ������� �� ���.
select Press.Name, sum(Books.Pages) as qty from Press
left join Books on Press.Id = Books.Id_Press
group by Press.name
having sum(Books.Pages) is not null

--�������� ����� ���-�� ����, ������ ���������� ���������� '����������������'.
	--select Students.Id from Faculties
	--left join Groups on Faculties.Id = Groups.Id_Faculty
	--left join Students on Students.Id_Group = Groups.Id
	--where Groups.Id_Faculty=1
select count(*) [���-�� ����] from S_Cards
WHERE Id_Student = ANY (select Students.Id from Groups left join Students on Students.Id_Group = Groups.Id where Groups.Id_Faculty=1)

--������� ���-�� ���� � ����� ������� ���� ���� �� ������� �� ����������� '�����','�����' � '�����-�����'.
select Press.Name,count(Press.Id) [���-�� ����] ,SUM(Books.Pages) [����� �������]
from Press
left join Books on Books.Id_Press =press.id
where Press.name in('�����','�����','�����-�����')
group by Press.Name

--������� ���������� � ����� �� ���������������� � ���������� ����������� �������.
select top 1 Books.Name,Comment,YearPress from Books 
left join Themes on Themes.Id = Books.Id_Themes
where Themes.Name='����������������'
order by Pages desc

--������� �� ����� ���-�� ������ ���� �� ������ �� ������.
select Faculties.Name,COUNT(id_book) [���-�� ������]
From S_Cards
left join Students on Students.id = S_Cards.Id_Student
left join Groups on Groups.Id = Students.Id_Group
left join Faculties on Faculties.Id = Groups.Id_Faculty
Group by Faculties.Name

--�������� ������������ � ����� ������ ����� ��� ������� �� ���.
Select Press.Name as PressName,Books.Name as BooksName,Query.Year
from(
	select Books.Id_Press, min(YearPress) as [Year]
	from Books
	Group By Books.Id_Press
	) as Query
Left join Press on Press.Id = Query.Id_Press
Left join Books on Books.YearPress = Query.Year and Books.Id_Press=Query.Id_Press

--�������� �����, ������� ����� � ������������� � �������� (��������� ����������).
Select Books.name from Books
where Books.id = any
(
	Select Id_Book from S_Cards
	union 
	Select Id_Book From T_Cards
)

--�������� �������� ����� � ������������ ���-��� ������� �� ������� �� �����������.
--(� ������ ����� �������� �� �������������, ����� ���� ������� ���� ������ ������ ������ �� ������)

select name,Quantity from 
(
	Select Id_Press,max(Pages) as maxQuantity from Books
	group by Id_Press
) as qyery
Left join Books on Books.Pages = qyery.maxQuantity and Books.Id_Press=qyery.Id_Press

--���������
--select * from Books
--Order by Id_Press,Quantity desc

