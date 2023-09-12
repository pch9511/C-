/*Select * From [LoginLog] Order by [Time] desc

Select * From [LoginLog] Where [Id] = '123456' AND [Time] IN (Select MAX([Time]) From [LoginLog] Where [Log] = '로그인')

Select * From [Mail] Where [RegiNum] = '123456' AND [Date] IN (Select MAX([Date]) From [Mail])

Select * From [Mail]*/

--INSert INTO [MAil] Values('123456','Admin','Test','테스트중입니다.',GetDate())

/*CREATE TABLE [dbo].[Category]
(
	[Id] NvarChar(3) NOT NULL PRIMARY KEY,
	[Name] NvarChar(20) NOT NULL,
	[Level] Int NOT NULL,
	[Parent] NvarChar(20) NULL
)*/
--SELECT * FROM [Order] Where [State] Like '%요청거부%'

--Select * From Category
--Select * From Product
--Delete From Product Where Id = 'A000'
--Select * From Itemback
--Select * From HeadStock


--Select * From [FranchiseInfo]

--Delete From HeadStock
--Select * From HeadStock
--Select * From FranStock Order by [Date] Desc 
--Select [RegiNum],Sum(Account * Price) as '총 매입액', Sum(Account) as '총 매입수량' From FranStock Where State ='입고' Group by [RegiNum]
--Select * From Product
--Select RegiNum,Sum(Account * -OutPrice) as 매출총액,[Pay] From HeadStock Where State ='출고' Group by [RegiNum],[Pay]
--Select RegiNum,Sum(Account * OutPrice) as 반품총액 From [ItemBack] Group by [RegiNum]
--Select [Id],Sum(Account * InPrice) as 매입총액,Sum(Account) as 수량 From HeadStock Where State ='입고' Group by [Id]
--Select [Id],Sum(Account * -OutPrice) as 매출총액,Sum(-Account) as 수량 From HeadStock Where State ='출고' Group by [Id]
--Select [Id],Sum(Account * OutPrice) as 반품총액,Sum(Account) as 수량,[State] From [ItemBack] Group by [Id],[State]
--Delete From FranStock Where Account=20000
--Drop Table HeadStock
--Delete From [Product]
--Drop Table [Order]
--Delete From [Order]
--Select * From [Order]
--Select * From [ItemBack]
--Select * From [Menu]
--Delete From Pay
--Select * From Pay Order by [Date] Asc
--Select * From SellProduct Order by [Date] Asc
--Select * From FranStock Where 
--Select * From [SellProduct]
--Select Top(5) [Name],Sum(Account) as 판매량 From [SellProduct] Group by [Name]

--Select * From [Mail]

--Select * From [LoginLog]
--Select * From Mail	
--Select * From ChatLog Order By [Date] Asc
--Delete From ChatLog
--Select [RegiNum],[Name],[Price],[Date] From FranStock
                --Where RegiNum = '123456' UNION  
                --Select [RegiNum],[Content],[Price],[Date] From Pay Where RegiNum = '123456' Order by [Date] Asc

--Select * From ChatLog
--Select [Id],[Name],[InPrice] ,sum(Account) as Account From HeadStock Group By [Id],[Name],[InPrice] Order by Account asc
--Delete From ChatRoom

--Select * From ChatRoom
--Select * From Mail

--Insert INTO category Values('C','Test','3','Test')

--DELETE From Category
--ALTER TABLE [Category] ADD [Parent] NvarChar(20) NULL;

--DROP TABLE Category 


/*CREATE TABLE [dbo].[Return]
(
	지점
	제품코드
	제품명
	가격
	수량
	반품사유 
	갱신일
)*/


--Select [Id],[Name],[InPrice],[OutPrice],[Account],[Date],[State],[Pay] From [HeadStock]
--union
--Select * From [HeadStock] Order by [Date] asc
--Update Top(1) [HeadStock] Set State = '불량' Where State = '출고' 
--Select * From [HeadStock] Order by [Date] asc
--Update Top(1) [HeadStock] Set State = '출고' Where [State] = '불량' and [Id] = 'BDA000' and [Account] = '-100' and [OutPrice] = '1800'
--Delete From [ORder]
--Delete From [HeadStock] Where [State] = '반품'
--Delete TOp(1) From [ItemBack]

--Select * From [Order]
--Update [HeadStock] Set State = '출고' Where [Date] = '2023-06-13 11:45:06.810'
--Update [Order] Set [State] = '반품요청 : 불량'  Where [State] = '반품완료'
--Select * From [Itemback]
