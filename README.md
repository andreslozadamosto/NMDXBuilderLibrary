NMDXBuilderLibrary
==================

Simple and powerful MDX Builder library for C#

Description
-----------
This library help us to create MDX queries easily. It's based on Decorator pattern to create the query. 

Targets
-------
It was tested on MS SQL Analysis Server (SSAS) and SAP BW enviroments (you can add Variables for BW QueryCubes ).

Examples
--------

__MDX generator for SAP__
	//builder
	SAPMDXBuilder Builder = new SAPMDXBuilder();
	Builder.CubeName = "Ventas";

	//ROW Axis
	MDXAxis RowAxis = new MDXAxis(MDXAxis.ROW_AXIS);
	CrossJoin CrossJoin = new CrossJoin(new MemberAxisItem("[COUNTRY].Members"));
	CrossJoin.AddCrossJointTo(new MemberAxisItem("[CITY].Members"));
	RowAxis.AxisItem = new NonEmpty(CrossJoin);

	//Column Axis
	MDXAxis ColumnAxis = new MDXAxis(MDXAxis.COLUMN_AXIS);
	SetAxisItem setList = new SetAxisItem(new MemberAxisItem("[Measures].[ventas]"));
	setList.AddAxisItem(new MemberAxisItem("[Measures].[stock]"));
	ColumnAxis.AxisItem = new NonEmpty(setList);

	//Add Axis to Builder
	Builder.AddAxis(RowAxis);
	Builder.AddAxis(ColumnAxis);
	
	//Add SAP Variables
	Builder.AddVariable(new MDXSAPVariable("Country", true, MDXSAPVariable.COMP_EQ, "AR"));
	Builder.AddVariable(new MDXSAPVariable("Country", true, MDXSAPVariable.COMP_EQ, "CL"));
	
	string query = Builder.Build();
	
Implemented
-----------
Common MDX features
- Simple MDX Query (with template)
- Functions:
	- AVG
	- BottomCount
	- BottomSum
	- Count
	- Covariance
	- CovarianceN
	- CrossJoin
	- Head
	- NonEmpty
	- Order
	- Tail
	- TopCount
	- With feature (partially)
	- Where feature

Vendors
- SAP
	- QueryCube variables
- SSAS

Licence
-------
MIT
