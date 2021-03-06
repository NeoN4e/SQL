USE [library]

--Написать хранимую процедуру, подсчитывающую факториал числа. (5! = 1*2*3*4*5 = 120) (0! = 1) (факториала отрицательного числа не существует).
ALTER Procedure [dbo].[fact]
@value int out
as
  if (@value = 1) return 1
  if (@value = 0) Begin Set @value=1 return 1 end
  
  else
	begin
		declare @v int
		set @v=@value-1
		exec fact @v out
		
		Set @value = @value * @v
	End
return @value
Go

--Написать хранимую процедуру, возвращающую имя и фамилию библиотекаря, Количество выданных книг.
ALTER Procedure [dbo].[LibsBooks]
as
Select (Select FirstName+' '+LastName from Libs where id=Id_Lib), Count(id)
From
(
	Select Id_Lib,Id from S_Cards
	union 
	Select Id_Lib,Id from T_Cards
)as query
group by Id_Lib
Go

--Написать хранимую процедуру, возвращающую имя и фамилию библиотекаря, выдавшего наибольшее кол-во книг.
ALTER Procedure [dbo].[LibsMaxBook]
as
Select top 1 FirstName,LastName
from
(
	Select Id_Lib,Id from S_Cards
	union 
	Select Id_Lib,Id from T_Cards
)as query
left join Libs on Libs.id=query.Id_Lib
group by FirstName,LastName
order by Count(query.Id) desc