
/*
�������� ����� �������:
�������, ������������ ���-�� ���������, ������� �� ����� �����.
�������, ������������ ����������� �� ���� ���������� ����������.
�������, ������� ��������� � �������� ��������� ������������� ����� � ���������� ����� �� �������� ������, ���� ��� �����. (����������� % - ������� �� ������. ��������: 57%10=7)
�������, ������������ ���-�� ������ ���� �� ������ �� ����� � �� ������ �� ������ (departments).
�������, ������� ���������� ������ ������������� � ���-�� �������� ������ �� ��� ����.



�������� ����� ��������:
����� ��� ������ ������������ �����, �� ���-�� ����������� �� 1.
����� ��� �������� ������������ �����, �� ���-�� ������������� �� 1.
����� ������ ���� ������ �����, ������� ��� ��� � ���������� (�� ���-��).
����� ������ ���� ������ ����� ���� ���� ������ ��������.
����� ��� �������� �����, ������ � ��� ������������ � ������� ���������.
���� ����� ����������� � ����, ��� ������ ���� ������� �� ������� ���������.
*/

--�������, ������������ ���-�� ���������, ������� �� ����� �����.
/*
Alter Function SCountWithOutBooks() returns int
as
begin
	declare @Rezalt int
	select @Rezalt=Count(id) from Students
	where id != all(select Id_Student from S_Cards)

	return @Rezalt
end

GO
Print  dbo.SCountWithOutBooks()
*/

--�������, ������������ ����������� �� ���� ���������� ����������.
--Create Function My3Min(@a int, @b int, @c int) 
--	returns int
--as
--begin
	
--	if((@a<=@b) and (@a<=@c)) return @a

--	if((@b<=@a) and (@b<=@c)) return @b
	
--	return @c
--end

--Go
--Print dbo.My3Min(1,3,5)


--�������, ������� ��������� � �������� ��������� ������������� ����� � ���������� ����� �� �������� ������, ���� ��� �����. (����������� % - ������� �� ������. ��������: 57%10=7)
--Alter Function MyIntTest(@value int) returns int
--as
--begin
--	declare @Counter int
--	set @Counter=1

--	declare @MinValue int
--	set @MinValue = (@value % 10)
	
--	declare @temp int

--	while(@value/(10*@Counter) > 1)
--	begin
--		set @Counter = @Counter + 1
--		set @temp = @value%(10*@Counter)

--		if (@temp < @MinValue) set @MinValue=@temp
--	end

--	return @MinValue
--end
Go
print dbo.MyIntTest(23)