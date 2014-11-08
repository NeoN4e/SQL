--�������� �������� ���������, ������� ���������� �� ������������� 'BHV', � ����� ������� >= 3000 �����������.
Select name,press,pressrun
from books

where press not like 'BHV%' and pressrun >=3000

--�������� ��� �����-�������, ���� ������� ���� 30�.
Select name 
from books
Where new=1 and price <30

--�������� ��� �����, � ������� � ����� ����� ������� ����.
Select name 
from books
where name like '% % % % %'

--�������� �����, � ��������� ������� ���� ����� Microsoft, �� ��� ����� Windows
Select name 
from books
where name like '%Microsoft%'

--�������� �����, � ������� ���� ����� �������� ������ 10 ������.
Select name,price,pages,price / pages as PagePrice
from books
where pages >0 and (price / pages <0.1) 

union 
Select name,price,pages, 0
from books
where pages=0


--�������� ����� � ���� � �.�. ��� ���� ���� �������.
Select name,Price
from books
where new =1

--�������� ��� �����, ��� ������� � ������� 2000, � ���� >30.
Select name,Price,date
from books
where 
date between '2000-01-01' and '2001-01-01' 
and Price>30