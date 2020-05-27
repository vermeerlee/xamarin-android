﻿﻿using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Build.Framework;
using NUnit.Framework;
using Xamarin.ProjectTools;

namespace Xamarin.Android.Build.Tests
{
	public partial class BuildTest : BaseTest
	{
#pragma warning disable 414
		static object [] AotChecks () => new object [] {
			new object[] {
				/* supportedAbis */   "armeabi-v7a",
				/* enableLLVM */      false,
				/* expectedResult */  true,
			},
			new object[] {
				/* supportedAbis */   "armeabi-v7a",
				/* enableLLVM */      true,
				/* expectedResult */  true,
			},
			new object[] {
				/* supportedAbis */   "arm64-v8a",
				/* enableLLVM */      false,
				/* expectedResult */  true,
			},
			new object[] {
				/* supportedAbis */   "arm64-v8a",
				/* enableLLVM */      true,
				/* expectedResult */  true,
			},
			new object[] {
				/* supportedAbis */   "x86",
				/* enableLLVM */      false,
				/* expectedResult */  true,
			},
			new object[] {
				/* supportedAbis */   "x86",
				/* enableLLVM */      true,
				/* expectedResult */  true,
			},
			new object[] {
				/* supportedAbis */   "x86_64",
				/* enableLLVM */      false,
				/* expectedResult */  true,
			},
			new object[] {
				/* supportedAbis */   "x86_64",
				/* enableLLVM */      true,
				/* expectedResult */  true,
			},
		};

		static object [] RuntimeChecks () => new object [] {
			new object[] {
				/* supportedAbi */     "armeabi-v7a",
				/* debugSymbols */     true ,
				/* debugType */        "Full",
				/* optimize */         true ,
				/* embedassebmlies */  true ,
				/* expectedResult */   "release",
			},
			new object[] {
				/* supportedAbi */     "armeabi-v7a",
				/* debugSymbols */     true ,
				/* debugType */        "Full",
				/* optimize */         true ,
				/* embedassebmlies */  false ,
				/* expectedResult */   CommercialBuildAvailable ? "debug" : "release",
			},
			new object[] {
				/* supportedAbi */     "armeabi-v7a",
				/* debugSymbols */     true ,
				/* debugType */        "Full",
				/* optimize */         false ,
				/* embedassebmlies */  true ,
				/* expectedResult */   "debug",
			},
			new object[] {
				/* supportedAbi */     "armeabi-v7a",
				/* debugSymbols */     true ,
				/* debugType */        "Full",
				/* optimize */         false ,
				/* embedassebmlies */  false ,
				/* expectedResult */   "debug",
			},
			new object[] {
				/* supportedAbi */     "armeabi-v7a",
				/* debugSymbols */     true ,
				/* debugType */        "",
				/* optimize */         true ,
				/* embedassebmlies */  true ,
				/* expectedResult */   "release",
			},
			new object[] {
				/* supportedAbi */     "armeabi-v7a",
				/* debugSymbols */     true ,
				/* debugType */        "",
				/* optimize */         true ,
				/* embedassebmlies */  false ,
				/* expectedResult */   CommercialBuildAvailable ? "debug" : "release",
			},
			new object[] {
				/* supportedAbi */     "armeabi-v7a",
				/* debugSymbols */     true ,
				/* debugType */        "",
				/* optimize */         false ,
				/* embedassebmlies */  true ,
				/* expectedResult */   "debug",
			},
			new object[] {
				/* supportedAbi */     "armeabi-v7a",
				/* debugSymbols */     true ,
				/* debugType */        "",
				/* optimize */         false ,
				/* embedassebmlies */  false ,
				/* expectedResult */   "debug",
			},
			new object[] {
				/* supportedAbi */     "armeabi-v7a",
				/* debugSymbols */     false ,
				/* debugType */        "",
				/* optimize */         null ,
				/* embedassebmlies */  null ,
				/* expectedResult */   CommercialBuildAvailable ? "debug" : "release",
			},
		};

		static object [] SequencePointChecks () => new object [] {
			new object[] {
				/* isRelease */          false,
				/* monoSymbolArchive */  false ,
				/* aotAssemblies */      false,
				/* debugSymbols */       true,
				/* debugType */          "Full",
				/* embedMdb */           !CommercialBuildAvailable, // because we don't use FastDev in the OSS repo
				/* expectedRuntime */    "debug",
			},
			new object[] {
				/* isRelease */          true,
				/* monoSymbolArchive */  false,
				/* aotAssemblies */      false,
				/* debugSymbols */       true,
				/* debugType */          "Full",
				/* embedMdb */           false,
				/* expectedRuntime */    "release",
			},
			new object[] {
				/* isRelease */          true,
				/* monoSymbolArchive */  true,
				/* aotAssemblies */      false,
				/* debugSymbols */       true,
				/* debugType */          "Full",
				/* embedMdb */           false,
				/* expectedRuntime */    "release",
			},
			new object[] {
				/* isRelease */          true,
				/* monoSymbolArchive */  true ,
				/* aotAssemblies */      false,
				/* debugSymbols */       true,
				/* debugType */          "PdbOnly",
				/* embedMdb */           false,
				/* expectedRuntime */    "release",
			},
			new object[] {
				/* isRelease */          true,
				/* monoSymbolArchive */  true ,
				/* aotAssemblies */      true,
				/* debugSymbols */       true,
				/* debugType */          "PdbOnly",
				/* embedMdb */           false,
				/* expectedRuntime */    "release",
			},
			new object[] {
				/* isRelease */          true,
				/* monoSymbolArchive */  false ,
				/* aotAssemblies */      false,
				/* debugSymbols */       true,
				/* debugType */          "PdbOnly",
				/* embedMdb */           false,
				/* expectedRuntime */    "release",
			},
			new object[] {
				/* isRelease */          true,
				/* monoSymbolArchive */  false ,
				/* aotAssemblies */      true,
				/* debugSymbols */       false,
				/* debugType */          "",
				/* embedMdb */           false,
				/* expectedRuntime */    "release",
			},
			new object[] {
				/* isRelease */          true,
				/* monoSymbolArchive */  true ,
				/* aotAssemblies */      true,
				/* debugSymbols */       false,
				/* debugType */          "",
				/* embedMdb */           false,
				/* expectedRuntime */    "release",
			},
		};
#pragma warning restore 414
	}
}

