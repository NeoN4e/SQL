--create function Chet(@a int)
--returns varchar(50)
--as
--begin
--	declare @res varchar(50)
--	if(@a=0)
--		set @res = 'Ноль'
--	else
--		if(@a%2=0)
--			set @res = 'Четное'
--		else
--			set @res = 'Нечетное'
--	return @res 
		
--end

--select dbo.Chet(34)

--declare @res varchar(50)
--exec @res = Chet 123
--select @res

--create function CountUsers()
--returns int
--as
--begin
--declare @r int 
--select @r = count (distinct loginame)
--from sysprocesses
--return @r
--end
--select dbo.CountUsers()

--create function ListStudent()
--returns table
--as
--return (
--	select Students.FirstName + ' ' + Students.LastName as FullName, Groups.Name, Students.Term
--	from Students inner join Groups on Students.Id_Group = Groups.Id
--)

--select *
--from dbo.ListStudent()


--create function AuthorsBooks()
--returns @tResult table(author varchar(100), quantity int)
--as
--begin
--	declare @tTemp table(author1 varchar(100), quantity1 int)
	
--	insert @tTemp
--	select Authors.FirstName + ' ' + Authors.LastName, count(S_Cards.Id_Book)
--	from (Authors inner join Books on Authors.Id = Books.Id_Author) inner join S_Cards on Books.Id = S_Cards.Id_Book
--	group by Authors.FirstName + ' ' + Authors.LastName
	
--	insert @tTemp
--	select Authors.FirstName + ' ' + Authors.LastName, count(T_Cards.Id_Book)
--	from (Authors inner join Books on Authors.Id = Books.Id_Author) inner join T_Cards on Books.Id = T_Cards.Id_Book
--	group by Authors.FirstName + ' ' + Authors.LastName

--	insert @tResult
--	select t.author1, sum(t.quantity1)
--	from @tTemp as t
--	group by t.author1
--	return
--end

--select *
--from dbo.AuthorsBooks()






