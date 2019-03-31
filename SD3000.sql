--用户表
select * from operator

--凭证字
Select id,typeid,name from CredType 
 where ID=1
 --科目
 Select subid,subcode,name,fullname,fdisplayname=subcode+fullname from Subject 
 where detailflag = 'T' and ((specialcode <> '113' and specialcode <> '115' and specialcode <> '203' and specialcode <> '204') or specialcode is null)  
 order by subcode 
 --币种
 select * from currency where moneyid<>99
 --分支机构
 select * from shop
 --
 Select * from Report where (RPTTYPE > 19 and RPTTYPE < 22 or RPTTYPE = 28 or RPTTYPE = 29 or  RPTTYPE = 30 OR RPTTYPE = 31) and RPTID > 0

 --凭证主表 Credence
 exec sp_executesql N'select * from Credence where Credid = @P1 
',N'@P1 varchar(4)','-999'
--CredItem 凭证细表
exec sp_executesql N'select C.*, s.subcode,S.DCFLAG, S.HSCASH,s.hswbflag,s.fullname 
from CredItem C, Subject S
where C.SubID = S.SubID and C.Credid = @P1 
',N'@P1 varchar(4)','-999'

--SET NO_BROWSETABLE ON
--凭证ID
select isnull(max(CredID), 100000000000) as maxcredid from Credence where credid like '____________'
--凭证号
SELECT Max(CredNo) as MaxCredNo from Credence 
 WHERE creddate >= '2014-03-01' and  creddate <= '2014-03-31 23:59:59'
credtypeid
-- 插入凭证主表
exec sp_executesql N'INSERT INTO "SD11211N_10".."Credence" 
("credid","shopid","credtype","rptid","credcode","credno","creddate","billnumber","billmaker","billcheck","billpost","checkflag","postflag","relevantbillid","credtypeid") 
VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10,@P11,@P12,@P13,@P14,@P15)',N'@P1 varchar(12),@P2 int,@P3 int,@P4 int,@P5 int,@P6 int,@P7 datetime,@P8 int,@P9 varchar(10),@P10 varchar(1),@P11 varchar(1),@P12 varchar(1),@P13 varchar(1),@P14 int,@P15 int','100000000001',0,0,20,1,1,'2019-03-29 00:00:00',0,'系统管理员','','','F','F',0,1
--插入凭证细表
exec sp_executesql N'INSERT INTO "SD11211N_10".."CredItem" ("credid","fenluno","rate","rawdebit","rawcredit","debit","credit","moneyid","subid","brief") VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10); INSERT INTO "SD11211N_10".."CredItem" ("credid","fenluno","rate","rawdebit","rawcredit","debit","credit","moneyid","subid","brief","attrflag","readonly") VALUES (@P11,@P12,@P13,@P14,@P15,@P16,@P17,@P18,@P19,@P20,@P21,@P22)',N'@P1 varchar(12),@P2 int,@P3 numeric(18,8),@P4 numeric(18,2),@P5 numeric(18,2),@P6 numeric(18,2),@P7 numeric(18,2),@P8 int,@P9 int,@P10 varchar(3),@P11 varchar(12),@P12 int,@P13 numeric(18,8),@P14 numeric(18,2),@P15 numeric(18,2),@P16 numeric(18,2),@P17 numeric(18,2),@P18 int,@P19 int,@P20 varchar(3),@P21 int,@P22 varchar(1)','100000000001',1,1.00000000,0.00,0.00,30.00,0.00,0,2,'AAA','100000000001',2,1.00000000,0.00,0.00,0.00,30.00,0,180,'BBB',0,'F'

select * from CredItem where credid='100000000002'
 


