
//----------------------------------------------------------------------------------
// <autogenerated>
//		This code was generated by a tool.
//		Changes to this file may cause incorrect behaviour and will be lost 
//		if the code is regenerated.
// </autogenerated>
//----------------------------------------------------------------------------------

using System;
using System.Text;
using System.Collections;
using System.ComponentModel;
using Soneta.Types;
using Soneta.Business;
using Soneta.Zadania;
using projekt.git.Tabele;
using Soneta.Kadry;
using projekt.git;

[assembly: ModuleType("git", typeof(projekt.git.gitModule), 2, "git", 1, VersionNumber=14)]

namespace projekt.git {

	/// <summary>
	/// Moduł git.
	/// <seealso cref="Soneta.Zadania"/>
	/// <seealso cref="projekt.git.Tabele"/>
	/// <seealso cref="Soneta.Kadry"/>
	/// </summary>
	/// <seealso cref="Soneta.Business.Module"/>
	/// <seealso cref="Soneta.Business.Session"/>
	[System.CodeDom.Compiler.GeneratedCode("Soneta.Generator", "2")]
	public partial class gitModule : Module {

		public static gitModule GetInstance(ISessionable session) {
			if (session == null || session.Session == null) return null;
			return (gitModule)session.Session.Modules[typeof(gitModule)];
		}

		/// <summary>
		/// Standardowy kontruktor modułu sesji.
		/// </summary>
		/// <param name="session">Sesja w której jest tworzony ten moduł.</param>
		public gitModule(Session session) : base(session, "git") {
			AddTable(tableDefinicjaBrunch);
			Initialize();
		}

		ZadaniaModule moduleZadania = null;

		[Browsable(false)]
		public ZadaniaModule Zadania {
			get {
				if (moduleZadania==null)
				    moduleZadania = ZadaniaModule.GetInstance(Session);
				return moduleZadania;
			}
		}

		KadryModule moduleKadry = null;

		[Browsable(false)]
		public KadryModule Kadry {
			get {
				if (moduleKadry==null)
				    moduleKadry = KadryModule.GetInstance(Session);
				return moduleKadry;
			}
		}

		static int handleProjektBrunche = 0;

		private ProjektBrunche tableDefinicjaBrunch = new ProjektBrunche();
		/// <summary>
		/// Tabela DefinicjaBrunch.
		/// </summary>
		public ProjektBrunche ProjektBrunche {
			get { return tableDefinicjaBrunch; } 
		}

		/// <summary>
		/// Klasa implementująca standardową obsługę tabeli obiektów DefinicjaBrunch.
		/// Dziedzicząca klasa <see cref="ProjektBrunche"/> zawiera kod użytkownika
		/// zawierający specyficzną funkcjonalność tabeli, która nie zawiera się w funkcjonalności
		/// biblioteki <see cref="Soneta.Business"/>.
		/// </summary>
		/// <seealso cref="ProjektBrunche"/>
		/// <seealso cref="DefinicjaBrunchRow"/>
		/// <seealso cref="DefinicjaBrunch"/>
		/// <seealso cref="Soneta.Business.Table"/>
		[TableName("DefinicjaBrunch", "Definicj", "ProjektBrunche", typeof(DefinicjaBrunch))]
		public abstract partial class DefinicjaBrunchTable : Table {

			protected DefinicjaBrunchTable() : base(false, false) {
			}

			public class ProjektRelation : SimpleRelation {
				protected override object [] GetData(Row row, Record rec) {
					return new object[] {
						((DefinicjaBrunchRecord)rec).Projekt,
						row.ID};
				}
				public ProjektRelation(DefinicjaBrunchTable table) {
					Table = table;
					Name = "Relacja dokumentow";
					ParentName = "Projekt";
					ChildColumn = "Projekt";
					DeleteCascade = true;
					Guided = RelationGuidedType.Inner;
					InitFields("Projekt", "ID");
					table.Session.Keys.Add(this);
				}

				public SubTable this[Projekt projekt] {
					get {
						return new SubTable(this, projekt);
					}
				}
			}

			ProjektRelation relationProjekt;

			public ProjektRelation WgProjekt {
				get { return relationProjekt; } 
			}

			public class PracownikRelation : SimpleRelation {
				protected override object [] GetData(Row row, Record rec) {
					return new object[] {
						((DefinicjaBrunchRecord)rec).Pracownik,
						row.ID};
				}
				public PracownikRelation(DefinicjaBrunchTable table) {
					Table = table;
					Name = "Relacja dokumentow";
					ParentName = "Pracownik";
					ChildColumn = "Pracownik";
					DeleteCascade = true;
					Guided = RelationGuidedType.Inner;
					InitFields("Pracownik", "ID");
					table.Session.Keys.Add(this);
				}

				public SubTable this[Pracownik pracownik] {
					get {
						return new SubTable(this, pracownik);
					}
				}
			}

			PracownikRelation relationPracownik;

			public PracownikRelation WgPracownik {
				get { return relationPracownik; } 
			}

			public class WgdataKey : Key {
				protected override object [] GetData(Row row, Record rec) {
					return new object[] {
						((DefinicjaBrunchRecord)rec).data,
						row.ID};
				}
				public WgdataKey(DefinicjaBrunchTable table) {
					Table = table;
					Name = "Wgdata";
					InitFields("data", "ID");
					table.Session.Keys.Add(this);
				}

				public SubTable this[Date data] {
					get {
						return new SubTable(this, data);
					}
				}
			}

			WgdataKey keyWgdata;

			public WgdataKey Wgdata {
				get { return keyWgdata; } 
			}


			protected override void LoadChildRelations() {
			}

			/// <summary>
			/// Typowane property dostarczające obiekt modułu zawierającegą tą tabelę. Umożliwia dostęp do
			/// innych obiektów znajdujących się w tym samym module.
			/// </summary>
			/// <seealso cref="gitModule"/>
			public new gitModule Module {
				get { return (gitModule)base.Module; } 
			}

			/// <summary>
			/// Typowany indekser dostarczający obiekty znajdujące się w tej tabeli przy pomocy 
			/// ID identyfikującego jednoznacznie obiekt w systemie.
			/// </summary>
			/// <param name="id">Liczba będąca unikalnym identyfikatorem obiektu. Wartości
			/// ujemne identyfikują obiekty, które zostały dodane i nie są jeszcze zapisane do bazy danych.</param>
			/// <seealso cref="DefinicjaBrunch"/>
			public new DefinicjaBrunch this[int id] {
				get { return (DefinicjaBrunch)base[id]; } 
			}

			protected override void Adding(Module module) {
				base.Adding(module);
				relationProjekt = new ProjektRelation(this);
				relationPracownik = new PracownikRelation(this);
				keyWgdata = new WgdataKey(this);
				SetPrimaryKey(keyWgdata);
			}

			protected override Record CreateRecord() {
				return new DefinicjaBrunchRecord();
			}

			protected override Row CreateRow(RowCreator creator) {
				return new DefinicjaBrunch(creator);
			}

			/// <summary>
			/// Metoda zwracająca typ wierszy znajdujących się w tej tabeli.
			/// </summary>
			/// <returns>Metoda zwraca zawsze wartość typeof(DefinicjaBrunch).</returns>
			/// <seealso cref="DefinicjaBrunch"/>
			public override Type GetRowType() {
				return typeof(DefinicjaBrunch);
			}

			protected override sealed int GetTableHandle() {
				return handleProjektBrunche;
			}

			protected override sealed void PrepareNames(StringBuilder names, string divider, bool prepareTextFields) {
				names.Append(divider); names.Append("data");
				names.Append(divider); names.Append("brunch");
				names.Append(divider); names.Append("Projekt");
				names.Append(divider); names.Append("Pracownik");
			}

			protected override sealed void PrepareTypes(System.Collections.Generic.List<Type> types) {
				types.Add(typeof(DateTime));
				types.Add(typeof(string));
				types.Add(typeof(Row));
				types.Add(typeof(Row));
			}

		}

		[RecordType(typeof(DefinicjaBrunchRecord))]
		[Caption("Tabela brunchy")]
		public abstract partial class DefinicjaBrunchRow : Row {

			private DefinicjaBrunchRecord record = null;


			protected override void AssignRecord(Record rec) {
				record = (DefinicjaBrunchRecord)rec;
			}

			protected DefinicjaBrunchRow(RowCreator creator) : base(false) {
			}

			protected DefinicjaBrunchRow([Required] Projekt projekt) : base(true) {
				if (projekt==null) throw new RequiredException(this, "Projekt");
				GetRecord();
				record.Projekt = projekt;
			}

			[Description("data okresu")]
			[Category("Ogólne")]
			public Date data {
				get {
					if (record==null) GetRecord();
					return record.data;
				}
				set {
					if (DefinicjaBrunchSchema.dataBeforeEdit!=null)
						DefinicjaBrunchSchema.dataBeforeEdit((DefinicjaBrunch)this, ref value);
					GetEdit(record==null, false);
					record.data = value;
					if (State!=RowState.Detached) {
						Table.Wgdata.ResyncSet(this);
					}
					if (DefinicjaBrunchSchema.dataAfterEdit!=null)
						DefinicjaBrunchSchema.dataAfterEdit((DefinicjaBrunch)this);
				}
			}

			[MaxLength(250)]
			public string brunch {
				get {
					if (record==null) GetRecord();
					return record.brunch;
				}
				set {
					if (DefinicjaBrunchSchema.brunchBeforeEdit!=null)
						DefinicjaBrunchSchema.brunchBeforeEdit((DefinicjaBrunch)this, ref value);
					if (value!=null) value = value.TrimEnd();
					if (value.Length>brunchLength) throw new ValueToLongException(this, "brunch", brunchLength);
					GetEdit(record==null, false);
					record.brunch = value;
					if (DefinicjaBrunchSchema.brunchAfterEdit!=null)
						DefinicjaBrunchSchema.brunchAfterEdit((DefinicjaBrunch)this);
				}
			}

			public const int brunchLength = 250;

			[Description("Projekt do którego przypisane są brunche")]
			[Category("Ogólne")]
			[Caption("Projekt")]
			[Required]
			public Projekt Projekt {
				get {
					if (record==null) GetRecord();
					if (record.Projekt==null) return null;
					Projekt row = (Projekt)record.Projekt.Root;
					record.Projekt = row;
					return row;
				}
			}

			[Description("Projekt do którego przypisane są brunche")]
			[Category("Ogólne")]
			[Caption("Pracownik")]
			public Pracownik Pracownik {
				get {
					if (record==null) GetRecord();
					if (record.Pracownik==null) return null;
					Pracownik row = (Pracownik)record.Pracownik.Root;
					record.Pracownik = row;
					return row;
				}
				set {
					if (DefinicjaBrunchSchema.PracownikBeforeEdit!=null)
						DefinicjaBrunchSchema.PracownikBeforeEdit((DefinicjaBrunch)this, ref value);
					System.Diagnostics.Debug.Assert(value==null || State==RowState.Detached || value.State==RowState.Detached || Session==value.Session);
					GetEdit(record==null, false);
					record.Pracownik = value;
					LockGuidedRoot();
					if (State!=RowState.Detached) {
						Table.WgPracownik.ResyncSet(this);
					}
					if (DefinicjaBrunchSchema.PracownikAfterEdit!=null)
						DefinicjaBrunchSchema.PracownikAfterEdit((DefinicjaBrunch)this);
				}
			}

			[Browsable(false)]
			public new ProjektBrunche Table {
				get { return (ProjektBrunche)base.Table; }
			}

			[Browsable(false)]
			public gitModule Module {
				get { return Table.Module; }
			}

			protected override sealed int GetTableHandle() {
				return handleProjektBrunche;
			}

			protected override Record CreateRecord() {
				return new DefinicjaBrunchRecord();
			}

			public sealed override AccessRights GetObjectRight() {
				AccessRights ar = CalcObjectRight();
				if (DefinicjaBrunchSchema.OnCalcObjectRight!=null)
					DefinicjaBrunchSchema.OnCalcObjectRight((DefinicjaBrunch)this, ref ar);
				return ar;
			}

			protected sealed override AccessRights GetParentsObjectRight() {
				AccessRights result = CalcParentsObjectRight();
				if (DefinicjaBrunchSchema.OnCalcParentsObjectRight!=null)
					DefinicjaBrunchSchema.OnCalcParentsObjectRight((DefinicjaBrunch)this, ref result);
				return result;
			}

			protected override void OnAdded() {
				base.OnAdded();
				System.Diagnostics.Debug.Assert(record.Projekt==null || record.Projekt.State==RowState.Detached || Session==record.Projekt.Session);
				System.Diagnostics.Debug.Assert(record.Pracownik==null || record.Pracownik.State==RowState.Detached || Session==record.Pracownik.Session);
				if (DefinicjaBrunchSchema.OnAdded!=null)
					DefinicjaBrunchSchema.OnAdded((DefinicjaBrunch)this);
			}

			protected override void OnLoaded() {
				base.OnLoaded();
				if (DefinicjaBrunchSchema.OnLoaded!=null)
					DefinicjaBrunchSchema.OnLoaded((DefinicjaBrunch)this);
			}

			protected override void OnEditing() {
				base.OnEditing();
				if (DefinicjaBrunchSchema.OnEditing!=null)
					DefinicjaBrunchSchema.OnEditing((DefinicjaBrunch)this);
			}

			protected override void OnDeleting() {
				base.OnDeleting();
				if (DefinicjaBrunchSchema.OnDeleting!=null)
					DefinicjaBrunchSchema.OnDeleting((DefinicjaBrunch)this);
			}

			protected override void OnDeleted() {
				base.OnDeleted();
				if (DefinicjaBrunchSchema.OnDeleted!=null)
					DefinicjaBrunchSchema.OnDeleted((DefinicjaBrunch)this);
			}

			protected override void LockGuidedRoot() {
				    LockGuidedRoot((Row)Projekt);
			}

			public override GuidedRow GetGuidedRoot() {
				Row r = (Row)Projekt;
				return r==null ? null : r.GetGuidedRoot();
			}

		}

		[ParentTable("DefinicjaBrunch")]
		public sealed class DefinicjaBrunchRecord : Record {
			public Date data;
			[MaxLength(250)]
			public string brunch = "";
			[Required]
			[ParentTable("Projekt")]
			public IRow Projekt;
			[ParentTable("Pracownik")]
			public IRow Pracownik;

			public override Record Clone() {
				DefinicjaBrunchRecord rec = (DefinicjaBrunchRecord)MemberwiseClone();
				return rec;
			}

			public override void Load(RowCreator creator, int delta) {
				System.Diagnostics.Debug.Assert(delta==0);
				data = creator.Load_date(1);
				brunch = creator.Load_string(2);
				Projekt = creator.Load_Row(3, "Projekty");
				Pracownik = creator.Load_Row(4, "Pracownicy");
			}
		}

		public static class DefinicjaBrunchSchema {

			internal static RowDelegate<DefinicjaBrunchRow, Date> dataBeforeEdit;
			public static void AdddataBeforeEdit(RowDelegate<DefinicjaBrunchRow, Date> value) {
				dataBeforeEdit = (RowDelegate<DefinicjaBrunchRow, Date>)Delegate.Combine(dataBeforeEdit, value);
			}

			internal static RowDelegate<DefinicjaBrunchRow> dataAfterEdit;
			public static void AdddataAfterEdit(RowDelegate<DefinicjaBrunchRow> value) {
				dataAfterEdit = (RowDelegate<DefinicjaBrunchRow>)Delegate.Combine(dataAfterEdit, value);
			}

			internal static RowDelegate<DefinicjaBrunchRow, string> brunchBeforeEdit;
			public static void AddbrunchBeforeEdit(RowDelegate<DefinicjaBrunchRow, string> value) {
				brunchBeforeEdit = (RowDelegate<DefinicjaBrunchRow, string>)Delegate.Combine(brunchBeforeEdit, value);
			}

			internal static RowDelegate<DefinicjaBrunchRow> brunchAfterEdit;
			public static void AddbrunchAfterEdit(RowDelegate<DefinicjaBrunchRow> value) {
				brunchAfterEdit = (RowDelegate<DefinicjaBrunchRow>)Delegate.Combine(brunchAfterEdit, value);
			}

			internal static RowDelegate<DefinicjaBrunchRow, Pracownik> PracownikBeforeEdit;
			public static void AddPracownikBeforeEdit(RowDelegate<DefinicjaBrunchRow, Pracownik> value) {
				PracownikBeforeEdit = (RowDelegate<DefinicjaBrunchRow, Pracownik>)Delegate.Combine(PracownikBeforeEdit, value);
			}

			internal static RowDelegate<DefinicjaBrunchRow> PracownikAfterEdit;
			public static void AddPracownikAfterEdit(RowDelegate<DefinicjaBrunchRow> value) {
				PracownikAfterEdit = (RowDelegate<DefinicjaBrunchRow>)Delegate.Combine(PracownikAfterEdit, value);
			}

			internal static RowDelegate<DefinicjaBrunchRow> OnLoaded;
			public static void AddOnLoaded(RowDelegate<DefinicjaBrunchRow> value) {
				OnLoaded = (RowDelegate<DefinicjaBrunchRow>)Delegate.Combine(OnLoaded, value);
			}

			internal static RowDelegate<DefinicjaBrunchRow> OnAdded;
			public static void AddOnAdded(RowDelegate<DefinicjaBrunchRow> value) {
				OnAdded = (RowDelegate<DefinicjaBrunchRow>)Delegate.Combine(OnAdded, value);
			}

			internal static RowDelegate<DefinicjaBrunchRow> OnEditing;
			public static void AddOnEditing(RowDelegate<DefinicjaBrunchRow> value) {
				OnEditing = (RowDelegate<DefinicjaBrunchRow>)Delegate.Combine(OnEditing, value);
			}

			internal static RowDelegate<DefinicjaBrunchRow> OnDeleting;
			public static void AddOnDeleting(RowDelegate<DefinicjaBrunchRow> value) {
				OnDeleting = (RowDelegate<DefinicjaBrunchRow>)Delegate.Combine(OnDeleting, value);
			}

			internal static RowDelegate<DefinicjaBrunchRow> OnDeleted;
			public static void AddOnDeleted(RowDelegate<DefinicjaBrunchRow> value) {
				OnDeleted = (RowDelegate<DefinicjaBrunchRow>)Delegate.Combine(OnDeleted, value);
			}

			internal static RowAccessRightsDelegate<DefinicjaBrunchRow> OnCalcObjectRight;
			public static void AddOnCalcObjectRight(RowAccessRightsDelegate<DefinicjaBrunchRow> value) {
				OnCalcObjectRight = (RowAccessRightsDelegate<DefinicjaBrunchRow>)Delegate.Combine(OnCalcObjectRight, value);
			}

			internal static RowAccessRightsDelegate<DefinicjaBrunchRow> OnCalcParentsObjectRight;
			public static void AddOnCalcParentsObjectRight(RowAccessRightsDelegate<DefinicjaBrunchRow> value) {
				OnCalcParentsObjectRight = (RowAccessRightsDelegate<DefinicjaBrunchRow>)Delegate.Combine(OnCalcParentsObjectRight, value);
			}

		}

	}
}

