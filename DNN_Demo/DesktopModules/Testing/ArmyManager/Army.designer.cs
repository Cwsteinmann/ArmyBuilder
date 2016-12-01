﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Testing.Dnn.ArmyManager.ArmyManager
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DNN_Demo")]
	public partial class ArmyDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertEngage_WargearUpgrade(Engage_WargearUpgrade instance);
    partial void UpdateEngage_WargearUpgrade(Engage_WargearUpgrade instance);
    partial void DeleteEngage_WargearUpgrade(Engage_WargearUpgrade instance);
    partial void InsertEngage_RulesUpgrade(Engage_RulesUpgrade instance);
    partial void UpdateEngage_RulesUpgrade(Engage_RulesUpgrade instance);
    partial void DeleteEngage_RulesUpgrade(Engage_RulesUpgrade instance);
    partial void InsertEngage_Unit_Rule(Engage_Unit_Rule instance);
    partial void UpdateEngage_Unit_Rule(Engage_Unit_Rule instance);
    partial void DeleteEngage_Unit_Rule(Engage_Unit_Rule instance);
    partial void InsertEngage_Unit_Wargear(Engage_Unit_Wargear instance);
    partial void UpdateEngage_Unit_Wargear(Engage_Unit_Wargear instance);
    partial void DeleteEngage_Unit_Wargear(Engage_Unit_Wargear instance);
    partial void InsertEngage_Army(Engage_Army instance);
    partial void UpdateEngage_Army(Engage_Army instance);
    partial void DeleteEngage_Army(Engage_Army instance);
    partial void InsertEngage_Unit(Engage_Unit instance);
    partial void UpdateEngage_Unit(Engage_Unit instance);
    partial void DeleteEngage_Unit(Engage_Unit instance);
    #endregion
		
		public ArmyDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ArmyDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ArmyDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ArmyDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ArmyDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Engage_WargearUpgrade> Engage_WargearUpgrades
		{
			get
			{
				return this.GetTable<Engage_WargearUpgrade>();
			}
		}
		
		public System.Data.Linq.Table<Engage_RulesUpgrade> Engage_RulesUpgrades
		{
			get
			{
				return this.GetTable<Engage_RulesUpgrade>();
			}
		}
		
		public System.Data.Linq.Table<Engage_Unit_Rule> Engage_Unit_Rules
		{
			get
			{
				return this.GetTable<Engage_Unit_Rule>();
			}
		}
		
		public System.Data.Linq.Table<Engage_Unit_Wargear> Engage_Unit_Wargears
		{
			get
			{
				return this.GetTable<Engage_Unit_Wargear>();
			}
		}
		
		public System.Data.Linq.Table<Engage_Army> Engage_Armies
		{
			get
			{
				return this.GetTable<Engage_Army>();
			}
		}
		
		public System.Data.Linq.Table<Engage_Unit> Engage_Units
		{
			get
			{
				return this.GetTable<Engage_Unit>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Engage_WargearUpgrades")]
	public partial class Engage_WargearUpgrade : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _WargearID;
		
		private string _Wargear;
		
		private EntitySet<Engage_Unit_Wargear> _Engage_Unit_Wargears;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnWargearIDChanging(int value);
    partial void OnWargearIDChanged();
    partial void OnWargearChanging(string value);
    partial void OnWargearChanged();
    #endregion
		
		public Engage_WargearUpgrade()
		{
			this._Engage_Unit_Wargears = new EntitySet<Engage_Unit_Wargear>(new Action<Engage_Unit_Wargear>(this.attach_Engage_Unit_Wargears), new Action<Engage_Unit_Wargear>(this.detach_Engage_Unit_Wargears));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WargearID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int WargearID
		{
			get
			{
				return this._WargearID;
			}
			set
			{
				if ((this._WargearID != value))
				{
					this.OnWargearIDChanging(value);
					this.SendPropertyChanging();
					this._WargearID = value;
					this.SendPropertyChanged("WargearID");
					this.OnWargearIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Wargear", DbType="NVarChar(60) NOT NULL", CanBeNull=false)]
		public string Wargear
		{
			get
			{
				return this._Wargear;
			}
			set
			{
				if ((this._Wargear != value))
				{
					this.OnWargearChanging(value);
					this.SendPropertyChanging();
					this._Wargear = value;
					this.SendPropertyChanged("Wargear");
					this.OnWargearChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Engage_WargearUpgrade_Engage_Unit_Wargear", Storage="_Engage_Unit_Wargears", ThisKey="WargearID", OtherKey="WargearID")]
		public EntitySet<Engage_Unit_Wargear> Engage_Unit_Wargears
		{
			get
			{
				return this._Engage_Unit_Wargears;
			}
			set
			{
				this._Engage_Unit_Wargears.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Engage_Unit_Wargears(Engage_Unit_Wargear entity)
		{
			this.SendPropertyChanging();
			entity.Engage_WargearUpgrade = this;
		}
		
		private void detach_Engage_Unit_Wargears(Engage_Unit_Wargear entity)
		{
			this.SendPropertyChanging();
			entity.Engage_WargearUpgrade = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Engage_RulesUpgrades")]
	public partial class Engage_RulesUpgrade : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _RuleID;
		
		private string _RuleName;
		
		private EntitySet<Engage_Unit_Rule> _Engage_Unit_Rules;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnRuleIDChanging(int value);
    partial void OnRuleIDChanged();
    partial void OnRuleNameChanging(string value);
    partial void OnRuleNameChanged();
    #endregion
		
		public Engage_RulesUpgrade()
		{
			this._Engage_Unit_Rules = new EntitySet<Engage_Unit_Rule>(new Action<Engage_Unit_Rule>(this.attach_Engage_Unit_Rules), new Action<Engage_Unit_Rule>(this.detach_Engage_Unit_Rules));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RuleID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int RuleID
		{
			get
			{
				return this._RuleID;
			}
			set
			{
				if ((this._RuleID != value))
				{
					this.OnRuleIDChanging(value);
					this.SendPropertyChanging();
					this._RuleID = value;
					this.SendPropertyChanged("RuleID");
					this.OnRuleIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RuleName", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
		public string RuleName
		{
			get
			{
				return this._RuleName;
			}
			set
			{
				if ((this._RuleName != value))
				{
					this.OnRuleNameChanging(value);
					this.SendPropertyChanging();
					this._RuleName = value;
					this.SendPropertyChanged("RuleName");
					this.OnRuleNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Engage_RulesUpgrade_Engage_Unit_Rule", Storage="_Engage_Unit_Rules", ThisKey="RuleID", OtherKey="RuleID")]
		public EntitySet<Engage_Unit_Rule> Engage_Unit_Rules
		{
			get
			{
				return this._Engage_Unit_Rules;
			}
			set
			{
				this._Engage_Unit_Rules.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Engage_Unit_Rules(Engage_Unit_Rule entity)
		{
			this.SendPropertyChanging();
			entity.Engage_RulesUpgrade = this;
		}
		
		private void detach_Engage_Unit_Rules(Engage_Unit_Rule entity)
		{
			this.SendPropertyChanging();
			entity.Engage_RulesUpgrade = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Engage_Unit_Rules")]
	public partial class Engage_Unit_Rule : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UnitID;
		
		private int _RuleID;
		
		private EntityRef<Engage_RulesUpgrade> _Engage_RulesUpgrade;
		
		private EntityRef<Engage_Unit> _Engage_Unit;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUnitIDChanging(int value);
    partial void OnUnitIDChanged();
    partial void OnRuleIDChanging(int value);
    partial void OnRuleIDChanged();
    #endregion
		
		public Engage_Unit_Rule()
		{
			this._Engage_RulesUpgrade = default(EntityRef<Engage_RulesUpgrade>);
			this._Engage_Unit = default(EntityRef<Engage_Unit>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UnitID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int UnitID
		{
			get
			{
				return this._UnitID;
			}
			set
			{
				if ((this._UnitID != value))
				{
					if (this._Engage_Unit.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUnitIDChanging(value);
					this.SendPropertyChanging();
					this._UnitID = value;
					this.SendPropertyChanged("UnitID");
					this.OnUnitIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RuleID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int RuleID
		{
			get
			{
				return this._RuleID;
			}
			set
			{
				if ((this._RuleID != value))
				{
					if (this._Engage_RulesUpgrade.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnRuleIDChanging(value);
					this.SendPropertyChanging();
					this._RuleID = value;
					this.SendPropertyChanged("RuleID");
					this.OnRuleIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Engage_RulesUpgrade_Engage_Unit_Rule", Storage="_Engage_RulesUpgrade", ThisKey="RuleID", OtherKey="RuleID", IsForeignKey=true)]
		public Engage_RulesUpgrade Engage_RulesUpgrade
		{
			get
			{
				return this._Engage_RulesUpgrade.Entity;
			}
			set
			{
				Engage_RulesUpgrade previousValue = this._Engage_RulesUpgrade.Entity;
				if (((previousValue != value) 
							|| (this._Engage_RulesUpgrade.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Engage_RulesUpgrade.Entity = null;
						previousValue.Engage_Unit_Rules.Remove(this);
					}
					this._Engage_RulesUpgrade.Entity = value;
					if ((value != null))
					{
						value.Engage_Unit_Rules.Add(this);
						this._RuleID = value.RuleID;
					}
					else
					{
						this._RuleID = default(int);
					}
					this.SendPropertyChanged("Engage_RulesUpgrade");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Engage_Unit_Engage_Unit_Rule", Storage="_Engage_Unit", ThisKey="UnitID", OtherKey="UnitId", IsForeignKey=true)]
		public Engage_Unit Engage_Unit
		{
			get
			{
				return this._Engage_Unit.Entity;
			}
			set
			{
				Engage_Unit previousValue = this._Engage_Unit.Entity;
				if (((previousValue != value) 
							|| (this._Engage_Unit.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Engage_Unit.Entity = null;
						previousValue.Engage_Unit_Rules.Remove(this);
					}
					this._Engage_Unit.Entity = value;
					if ((value != null))
					{
						value.Engage_Unit_Rules.Add(this);
						this._UnitID = value.UnitId;
					}
					else
					{
						this._UnitID = default(int);
					}
					this.SendPropertyChanged("Engage_Unit");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Engage_Unit_Wargear")]
	public partial class Engage_Unit_Wargear : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UnitID;
		
		private int _WargearID;
		
		private int _Amount;
		
		private EntityRef<Engage_WargearUpgrade> _Engage_WargearUpgrade;
		
		private EntityRef<Engage_Unit> _Engage_Unit;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUnitIDChanging(int value);
    partial void OnUnitIDChanged();
    partial void OnWargearIDChanging(int value);
    partial void OnWargearIDChanged();
    partial void OnAmountChanging(int value);
    partial void OnAmountChanged();
    #endregion
		
		public Engage_Unit_Wargear()
		{
			this._Engage_WargearUpgrade = default(EntityRef<Engage_WargearUpgrade>);
			this._Engage_Unit = default(EntityRef<Engage_Unit>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UnitID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int UnitID
		{
			get
			{
				return this._UnitID;
			}
			set
			{
				if ((this._UnitID != value))
				{
					if (this._Engage_Unit.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUnitIDChanging(value);
					this.SendPropertyChanging();
					this._UnitID = value;
					this.SendPropertyChanged("UnitID");
					this.OnUnitIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WargearID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int WargearID
		{
			get
			{
				return this._WargearID;
			}
			set
			{
				if ((this._WargearID != value))
				{
					if (this._Engage_WargearUpgrade.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnWargearIDChanging(value);
					this.SendPropertyChanging();
					this._WargearID = value;
					this.SendPropertyChanged("WargearID");
					this.OnWargearIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Amount", DbType="Int NOT NULL")]
		public int Amount
		{
			get
			{
				return this._Amount;
			}
			set
			{
				if ((this._Amount != value))
				{
					this.OnAmountChanging(value);
					this.SendPropertyChanging();
					this._Amount = value;
					this.SendPropertyChanged("Amount");
					this.OnAmountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Engage_WargearUpgrade_Engage_Unit_Wargear", Storage="_Engage_WargearUpgrade", ThisKey="WargearID", OtherKey="WargearID", IsForeignKey=true)]
		public Engage_WargearUpgrade Engage_WargearUpgrade
		{
			get
			{
				return this._Engage_WargearUpgrade.Entity;
			}
			set
			{
				Engage_WargearUpgrade previousValue = this._Engage_WargearUpgrade.Entity;
				if (((previousValue != value) 
							|| (this._Engage_WargearUpgrade.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Engage_WargearUpgrade.Entity = null;
						previousValue.Engage_Unit_Wargears.Remove(this);
					}
					this._Engage_WargearUpgrade.Entity = value;
					if ((value != null))
					{
						value.Engage_Unit_Wargears.Add(this);
						this._WargearID = value.WargearID;
					}
					else
					{
						this._WargearID = default(int);
					}
					this.SendPropertyChanged("Engage_WargearUpgrade");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Engage_Unit_Engage_Unit_Wargear", Storage="_Engage_Unit", ThisKey="UnitID", OtherKey="UnitId", IsForeignKey=true)]
		public Engage_Unit Engage_Unit
		{
			get
			{
				return this._Engage_Unit.Entity;
			}
			set
			{
				Engage_Unit previousValue = this._Engage_Unit.Entity;
				if (((previousValue != value) 
							|| (this._Engage_Unit.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Engage_Unit.Entity = null;
						previousValue.Engage_Unit_Wargears.Remove(this);
					}
					this._Engage_Unit.Entity = value;
					if ((value != null))
					{
						value.Engage_Unit_Wargears.Add(this);
						this._UnitID = value.UnitId;
					}
					else
					{
						this._UnitID = default(int);
					}
					this.SendPropertyChanged("Engage_Unit");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Engage_Army")]
	public partial class Engage_Army : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ArmyID;
		
		private string _ArmyName;
		
		private int _MaxPoints;
		
		private EntitySet<Engage_Unit> _Units;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnArmyIDChanging(int value);
    partial void OnArmyIDChanged();
    partial void OnArmyNameChanging(string value);
    partial void OnArmyNameChanged();
    partial void OnMaxPointsChanging(int value);
    partial void OnMaxPointsChanged();
    #endregion
		
		public Engage_Army()
		{
			this._Units = new EntitySet<Engage_Unit>(new Action<Engage_Unit>(this.attach_Units), new Action<Engage_Unit>(this.detach_Units));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ArmyID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ArmyID
		{
			get
			{
				return this._ArmyID;
			}
			set
			{
				if ((this._ArmyID != value))
				{
					this.OnArmyIDChanging(value);
					this.SendPropertyChanging();
					this._ArmyID = value;
					this.SendPropertyChanged("ArmyID");
					this.OnArmyIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ArmyName", DbType="NVarChar(60) NOT NULL", CanBeNull=false)]
		public string ArmyName
		{
			get
			{
				return this._ArmyName;
			}
			set
			{
				if ((this._ArmyName != value))
				{
					this.OnArmyNameChanging(value);
					this.SendPropertyChanging();
					this._ArmyName = value;
					this.SendPropertyChanged("ArmyName");
					this.OnArmyNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaxPoints")]
		public int MaxPoints
		{
			get
			{
				return this._MaxPoints;
			}
			set
			{
				if ((this._MaxPoints != value))
				{
					this.OnMaxPointsChanging(value);
					this.SendPropertyChanging();
					this._MaxPoints = value;
					this.SendPropertyChanged("MaxPoints");
					this.OnMaxPointsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Engage_Army_Engage_Unit", Storage="_Units", ThisKey="ArmyID", OtherKey="ArmyId")]
		public EntitySet<Engage_Unit> Units
		{
			get
			{
				return this._Units;
			}
			set
			{
				this._Units.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Units(Engage_Unit entity)
		{
			this.SendPropertyChanging();
			entity.Army = this;
		}
		
		private void detach_Units(Engage_Unit entity)
		{
			this.SendPropertyChanging();
			entity.Army = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Engage_Unit")]
	public partial class Engage_Unit : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UnitId;
		
		private int _ArmyId;
		
		private int _UnitType;
		
		private System.Nullable<int> _Squad;
		
		private int _Size;
		
		private EntitySet<Engage_Unit_Rule> _Engage_Unit_Rules;
		
		private EntitySet<Engage_Unit_Wargear> _Engage_Unit_Wargears;
		
		private EntityRef<Engage_Army> _Army;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUnitIdChanging(int value);
    partial void OnUnitIdChanged();
    partial void OnArmyIdChanging(int value);
    partial void OnArmyIdChanged();
    partial void OnUnitTypeChanging(int value);
    partial void OnUnitTypeChanged();
    partial void OnSquadChanging(System.Nullable<int> value);
    partial void OnSquadChanged();
    partial void OnSizeChanging(int value);
    partial void OnSizeChanged();
    #endregion
		
		public Engage_Unit()
		{
			this._Engage_Unit_Rules = new EntitySet<Engage_Unit_Rule>(new Action<Engage_Unit_Rule>(this.attach_Engage_Unit_Rules), new Action<Engage_Unit_Rule>(this.detach_Engage_Unit_Rules));
			this._Engage_Unit_Wargears = new EntitySet<Engage_Unit_Wargear>(new Action<Engage_Unit_Wargear>(this.attach_Engage_Unit_Wargears), new Action<Engage_Unit_Wargear>(this.detach_Engage_Unit_Wargears));
			this._Army = default(EntityRef<Engage_Army>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UnitId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int UnitId
		{
			get
			{
				return this._UnitId;
			}
			set
			{
				if ((this._UnitId != value))
				{
					this.OnUnitIdChanging(value);
					this.SendPropertyChanging();
					this._UnitId = value;
					this.SendPropertyChanged("UnitId");
					this.OnUnitIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ArmyId", DbType="Int NOT NULL")]
		public int ArmyId
		{
			get
			{
				return this._ArmyId;
			}
			set
			{
				if ((this._ArmyId != value))
				{
					if (this._Army.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnArmyIdChanging(value);
					this.SendPropertyChanging();
					this._ArmyId = value;
					this.SendPropertyChanged("ArmyId");
					this.OnArmyIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UnitType", DbType="Int NOT NULL")]
		public int UnitType
		{
			get
			{
				return this._UnitType;
			}
			set
			{
				if ((this._UnitType != value))
				{
					this.OnUnitTypeChanging(value);
					this.SendPropertyChanging();
					this._UnitType = value;
					this.SendPropertyChanged("UnitType");
					this.OnUnitTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Squad", DbType="Int")]
		public System.Nullable<int> Squad
		{
			get
			{
				return this._Squad;
			}
			set
			{
				if ((this._Squad != value))
				{
					this.OnSquadChanging(value);
					this.SendPropertyChanging();
					this._Squad = value;
					this.SendPropertyChanged("Squad");
					this.OnSquadChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Size", DbType="Int NOT NULL")]
		public int Size
		{
			get
			{
				return this._Size;
			}
			set
			{
				if ((this._Size != value))
				{
					this.OnSizeChanging(value);
					this.SendPropertyChanging();
					this._Size = value;
					this.SendPropertyChanged("Size");
					this.OnSizeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Engage_Unit_Engage_Unit_Rule", Storage="_Engage_Unit_Rules", ThisKey="UnitId", OtherKey="UnitID")]
		public EntitySet<Engage_Unit_Rule> Engage_Unit_Rules
		{
			get
			{
				return this._Engage_Unit_Rules;
			}
			set
			{
				this._Engage_Unit_Rules.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Engage_Unit_Engage_Unit_Wargear", Storage="_Engage_Unit_Wargears", ThisKey="UnitId", OtherKey="UnitID")]
		public EntitySet<Engage_Unit_Wargear> Engage_Unit_Wargears
		{
			get
			{
				return this._Engage_Unit_Wargears;
			}
			set
			{
				this._Engage_Unit_Wargears.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Engage_Army_Engage_Unit", Storage="_Army", ThisKey="ArmyId", OtherKey="ArmyID", IsForeignKey=true)]
		public Engage_Army Army
		{
			get
			{
				return this._Army.Entity;
			}
			set
			{
				Engage_Army previousValue = this._Army.Entity;
				if (((previousValue != value) 
							|| (this._Army.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Army.Entity = null;
						previousValue.Units.Remove(this);
					}
					this._Army.Entity = value;
					if ((value != null))
					{
						value.Units.Add(this);
						this._ArmyId = value.ArmyID;
					}
					else
					{
						this._ArmyId = default(int);
					}
					this.SendPropertyChanged("Army");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Engage_Unit_Rules(Engage_Unit_Rule entity)
		{
			this.SendPropertyChanging();
			entity.Engage_Unit = this;
		}
		
		private void detach_Engage_Unit_Rules(Engage_Unit_Rule entity)
		{
			this.SendPropertyChanging();
			entity.Engage_Unit = null;
		}
		
		private void attach_Engage_Unit_Wargears(Engage_Unit_Wargear entity)
		{
			this.SendPropertyChanging();
			entity.Engage_Unit = this;
		}
		
		private void detach_Engage_Unit_Wargears(Engage_Unit_Wargear entity)
		{
			this.SendPropertyChanging();
			entity.Engage_Unit = null;
		}
	}
}
#pragma warning restore 1591
