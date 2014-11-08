--¬ытащить название учебников, которые издавались не издательством 'BHV', и тираж которых >= 3000 экземпл€ров.
Select name,press,pressrun
from books

where press not like 'BHV%' and pressrun >=3000

--¬ытащить все книги-новинки, цена которых ниже 30р.
Select name 
from books
Where new=1 and price <30

--¬ытащить все книги, у которых в имени белее четырех слов.
Select name 
from books
where name like '% % % % %'

--¬ытащить книги, в названи€х которых есть слово Microsoft, но нет слова Windows
Select name 
from books
where name like '%Microsoft%'

--¬ытащить книги, у которых цена одной страницы меньше 10 копеек.
Select name,price,pages,price / pages as PagePrice
from books
where pages >0 and (price / pages <0.1) 

union 
Select name,price,pages, 0
from books
where pages=0


--¬ытащить книги и цену в у.е. дл€ всех книг новинок.
Select name,Price
from books
where new =1

--¬ычитать все книги, год издани€ у которых 2000, а цена >30.
Select name,Price,date
from books
where 
date between '2000-01-01' and '2001-01-01' 
and Price>30