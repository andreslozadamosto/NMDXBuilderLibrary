NMDXBuilderLibrary
==================

Simple and powerful MDX Builder library for C#

Description
-----------
This library help us to create MDX queries easily. It's based on Decorator pattern to create the query. 

Targets
-------
It was tested on MS SQL Analysis Server and SAP BW enviroments.

Examples
--------

__MDX generator__
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

	string query = Builder.build();
