// See https://aka.ms/new-console-template for more information
using System.Data;
using DotNetBatch14SNH.ConsoleApp2.AdoDotNetExamples;
using DotNetBatch14SNH.ConsoleApp2.DapperExamples;
using DotNetBatch14SNH.ConsoleApp2.EFCoreExamples;
using Microsoft.Data.SqlClient;

Console.WriteLine("Hello, World!");


//connection.Close();

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();

//adoDotNetExample.Edit("0930A539-4BF4-4914-A558-EDA61FC2BCA1");
//adoDotNetExample.Edit("0930A539-4BF4-4914-A558-EDA61FC2BCA2");
//adoDotNetExample.Create("test1", "test2", "test3");

//DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Create("test1 2", "test2 3", "test3 4");
//dapperExample.Update("E03C36DD-2002-49A4-A861-DAC316E631AE","new title","new author","new content");
//dapperExample.Delete("E03C36DD-2002-49A4-A861-DAC316E631AE");

EFCoreExample eFCoreExample = new EFCoreExample();
eFCoreExample.Read();


