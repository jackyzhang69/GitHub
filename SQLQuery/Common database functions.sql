create function fnComputeAge(@DOB datetime)
returns varchar(50)
as 
begin 

declare @tempdate datetime,@years int, @months int, @days int

select @tempdate=@DOB

select @years=datediff(year, @tempdate,getdate())-
    case
         when (month(@DOB)>month(getdate())) or 
         (month(@DOB)=month(getdate()) and day(@DOB)>day(getdate()))
          then 1 else 0
    end
select @tempdate=dateadd(year, @years,@tempdate)  -- add the year difference in order to only calculate months

select @months=DATEDIFF(month,@tempdate,getdate())-
     case
	     when day(@DOB)>DAY(getdate())
		 then 1 else 0
     end
select @tempdate=dateadd(month,@months,@tempdate) -- add the months difference in order to only calculate days

select @days=datediff(day, @tempdate,getdate())

declare @Age varchar(50)
set @Age=cast(@Years as varchar(4))+' Years'+cast(@months  as varchar(2))+' Months'+cast(@days as varchar(2))  +' Days age'

return @Age

end 

