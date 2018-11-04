/*
 Navicat Premium Data Transfer

 Source Server         : SQLSERVER_REMOTE
 Source Server Type    : SQL Server
 Source Server Version : 11002100
 Source Host           : bingqiangzhou.cn:1433
 Source Catalog        : Training
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 11002100
 File Encoding         : 65001

 Date: 04/11/2018 15:18:00
*/


-- ----------------------------
-- Table structure for Instance
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Instance]') AND type IN ('U'))
	DROP TABLE [dbo].[Instance]
GO

CREATE TABLE [dbo].[Instance] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [resourceAddress] nvarchar(128) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [key] nvarchar(16) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [image] nvarchar(32) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [title] nvarchar(128) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [code] nvarchar(2000) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [context] nvarchar(2000) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [result] nvarchar(1000) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Instance] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Instance
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Instance] ON
GO

INSERT INTO [dbo].[Instance] ([id], [resourceAddress], [key], [image], [title], [code], [context], [result]) VALUES (N'1', N'', N'斐波那契数列', NULL, N'古典问题：有一对兔子，从出生后第3个月起每个月都生一对兔子，小兔子长到第三个月后每个月又生一对兔子，假如兔子都不死，问每个月的兔子对数为多少？', N'public class Programme1 {

    public static void main(String[] args) {

       System.out.print("请输入你想知道的兔子数量的月份：");

       Scanner scanner=new Scanner(System.in);

       int n=scanner.nextInt();//获取输入的整数

       System.out.println("第"+n+"个月兔子总数为"+fun(n));

       scanner.close();

    }

    //求得所需月份的兔子的数量，返回值为兔子的数量

    private static int fun(intn){

       if(n==1 ||n==2)

          return 1;

       else

          returnfun(n-1)+fun(n-2);

           }

}
', N'兔子的规律为数列1,1,2,3,5,8,13,21....

          做这种题目，最好的做法就是找出规律，跟高中的数列一样

          本题有：a[n]=a[n-1]+a[n-1],而第一第二项都知道了，后面的值也可以求得', N'')
GO

INSERT INTO [dbo].[Instance] ([id], [resourceAddress], [key], [image], [title], [code], [context], [result]) VALUES (N'2', NULL, N'素数', NULL, N'判断101-200之间有多少个素数，并输出所有素数。', N'public class Programme2 {

 

    public static void main(String[] args) {

       int sum=0;

        for (inti = 100; i < 200;i++) {

           if (IsRightNum(i)) { //判断这个数是不是素数

              System.out.print(i+"  ");

              sum++;

              if (sum%10==0) { //十个一行

                  System.out.println();

              }

           }

       }

        System.out.println("素数的整数："+sum);

        

    }

   

    //判断这个数是不是素数的具体代码

    private static boolean IsRightNum(inti) {

       for (intj = 2; j < Math.sqrt(i);j++) {

           if (i%j==0) { //如果能整除，就说明不是素数，可以马上中断，继续对下一个数判断

              return false;

           }

       }     

        

       return true;

    }

 

}
', N'* 素数是：只能被1或本身整除的数，如：3,5,7,11,131... 

      *判断素数的方法：用一个数分别去除2到sqrt(这个数)，

      *其实用这个数分别去除2到他本身少1的数也可以，但是运算时间增加了

      *如果能被整除，则表明此数不是素数，反之是素数。
', NULL)
GO

INSERT INTO [dbo].[Instance] ([id], [resourceAddress], [key], [image], [title], [code], [context], [result]) VALUES (N'3', NULL, N'水仙花数', NULL, N'打印出所有的"水仙花数"，所谓"水仙花数"是指一个三位数，其各位数字立方和等于该数本身。例如：153是一个"水仙花数"，因为153=1的三次方＋5的三次方＋3的三次方。', N'public class Programme3 {

 

    public static void main(String[] args) {

       int sum=0;//水仙花的总数

       for (inti = 100; i < 1000;i++) {

           intbite=i%10;     //求得个位

           intten=i/10%10;  //求得十位

           inthundred=i/100;//求得百位

           //如果符合水仙花条件的数打印出来

           if (i==(bite*bite*bite)+

(ten*ten*ten)+(hundred*hundred*hundred)) {

              System.out.print(i+"  ");

              sum++;

           }

          

       }

       System.out.println("总共有水仙花个数："+sum);     

    }

}
', N'利用for循环控制100-999个数，每个数分解出个位，十位，百位。', NULL)
GO

SET IDENTITY_INSERT [dbo].[Instance] OFF
GO


-- ----------------------------
-- Primary Key structure for table Instance
-- ----------------------------
ALTER TABLE [dbo].[Instance] ADD CONSTRAINT [PK__Instance__3213E83F2760C0C0] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

