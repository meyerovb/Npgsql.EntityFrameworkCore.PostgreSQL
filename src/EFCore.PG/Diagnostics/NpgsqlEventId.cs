﻿using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Npgsql.EntityFrameworkCore.PostgreSQL.Diagnostics
{
    /// <summary>
    ///     <para>
    ///         Event IDs for PostgreSQL/Npgsql events that correspond to messages logged to an <see cref="ILogger" />
    ///         and events sent to a <see cref="DiagnosticSource" />.
    ///     </para>
    ///     <para>
    ///         These IDs are also used with <see cref="WarningsConfigurationBuilder" /> to configure the
    ///         behavior of warnings.
    ///     </para>
    /// </summary>
    public static class NpgsqlEventId
    {
        // Warning: These values must not change between releases.
        // Only add new values to the end of sections, never in the middle.
        // Try to use <Noun><Verb> naming and be consistent with existing names.
        private enum Id
        {
            // Model validation events

            // Scaffolding events
            ColumnFound = CoreEventId.ProviderDesignBaseId,
            //ColumnNotNamedWarning,
            //ColumnSkipped,
            //ForeignKeyColumnMissingWarning,
            //ForeignKeyColumnNotNamedWarning,
            //ForeignKeyColumnsNotMappedWarning,
            //ForeignKeyNotNamedWarning,
            ForeignKeyReferencesMissingPrincipalTableWarning,
            //IndexColumnFound,
            //IndexColumnNotNamedWarning,
            //IndexColumnSkipped,
            //IndexColumnsNotMappedWarning,
            //IndexNotNamedWarning,
            //IndexTableMissingWarning,
            MissingSchemaWarning,
            MissingTableWarning,
            SequenceFound,
            //SequenceNotNamedWarning,
            TableFound,
            //TableSkipped,
            //ForeignKeyTableMissingWarning,
            PrimaryKeyFound,
            UniqueConstraintFound,
            IndexFound,
            ForeignKeyFound,
            ForeignKeyPrincipalColumnMissingWarning,
            EnumColumnSkippedWarning,
            ExpressionIndexSkippedWarning,
            UnsupportedColumnIndexSkippedWarning,
            UnsupportedConstraintIndexSkippedWarning
        }

        private static readonly string _validationPrefix = DbLoggerCategory.Model.Validation.Name + ".";
        private static EventId MakeValidationId(Id id) => new EventId((int)id, _validationPrefix + id);

//        /// <summary>
//        ///     <para>
//        ///         No explicit type for a decimal column.
//        ///     </para>
//        ///     <para>
//        ///         This event is in the <see cref="DbLoggerCategory.Model.Validation" /> category.
//        ///     </para>
//        ///     <para>
//        ///         This event uses the <see cref="PropertyEventData" /> payload when used with a <see cref="DiagnosticSource" />.
//        ///     </para>
//        /// </summary>
//        public static readonly EventId DecimalTypeDefaultWarning = MakeValidationId(Id.DecimalTypeDefaultWarning);

        /// <summary>
        ///     <para>
        ///         A byte property is set up to use a SQL Server identity column.
        ///     </para>
        ///     <para>
        ///         This event is in the <see cref="DbLoggerCategory.Model.Validation" /> category.
        ///     </para>
        ///     <para>
        ///         This event uses the <see cref="PropertyEventData" /> payload when used with a <see cref="DiagnosticSource" />.
        ///     </para>
        /// </summary>
        //public static readonly EventId ByteIdentityColumnWarning = MakeValidationId(Id.ByteIdentityColumnWarning);

        private static readonly string _scaffoldingPrefix = DbLoggerCategory.Scaffolding.Name + ".";
        private static EventId MakeScaffoldingId(Id id) => new EventId((int)id, _scaffoldingPrefix + id);

        /// <summary>
        ///     A column was found.
        ///     This event is in the <see cref="DbLoggerCategory.Scaffolding" /> category.
        /// </summary>
        public static readonly EventId ColumnFound = MakeScaffoldingId(Id.ColumnFound);

        /// <summary>
        ///     The database is missing a schema.
        ///     This event is in the <see cref="DbLoggerCategory.Scaffolding" /> category.
        /// </summary>
        public static readonly EventId MissingSchemaWarning = MakeScaffoldingId(Id.MissingSchemaWarning);

        /// <summary>
        ///     The database is missing a table.
        ///     This event is in the <see cref="DbLoggerCategory.Scaffolding" /> category.
        /// </summary>
        public static readonly EventId MissingTableWarning = MakeScaffoldingId(Id.MissingTableWarning);

        /// <summary>
        ///     A foreign key references a missing table at the principal end.
        ///     This event is in the <see cref="DbLoggerCategory.Scaffolding" /> category.
        /// </summary>
        public static readonly EventId ForeignKeyReferencesMissingPrincipalTableWarning = MakeScaffoldingId(Id.ForeignKeyReferencesMissingPrincipalTableWarning);

        /// <summary>
        ///     A table was found.
        ///     This event is in the <see cref="DbLoggerCategory.Scaffolding" /> category.
        /// </summary>
        public static readonly EventId TableFound = MakeScaffoldingId(Id.TableFound);

        /// <summary>
        ///     A sequence was found.
        ///     This event is in the <see cref="DbLoggerCategory.Scaffolding" /> category.
        /// </summary>
        public static readonly EventId SequenceFound = MakeScaffoldingId(Id.SequenceFound);

        /// <summary>
        ///     Primary key was found.
        ///     This event is in the <see cref="DbLoggerCategory.Scaffolding" /> category.
        /// </summary>
        public static readonly EventId PrimaryKeyFound = MakeScaffoldingId(Id.PrimaryKeyFound);

        /// <summary>
        ///     An unique constraint was found.
        ///     This event is in the <see cref="DbLoggerCategory.Scaffolding" /> category.
        /// </summary>
        public static readonly EventId UniqueConstraintFound = MakeScaffoldingId(Id.UniqueConstraintFound);

        /// <summary>
        ///     An index was found.
        ///     This event is in the <see cref="DbLoggerCategory.Scaffolding" /> category.
        /// </summary>
        public static readonly EventId IndexFound = MakeScaffoldingId(Id.IndexFound);

        /// <summary>
        ///     A foreign key was found.
        ///     This event is in the <see cref="DbLoggerCategory.Scaffolding" /> category.
        /// </summary>
        public static readonly EventId ForeignKeyFound = MakeScaffoldingId(Id.ForeignKeyFound);

        /// <summary>
        ///     A principal column referenced by a foreign key was not found.
        ///     This event is in the <see cref="DbLoggerCategory.Scaffolding" /> category.
        /// </summary>
        public static readonly EventId ForeignKeyPrincipalColumnMissingWarning = MakeScaffoldingId(Id.ForeignKeyPrincipalColumnMissingWarning);

        /// <summary>
        ///     Enum column cannot be scaffolded, define a CLR enum type and add the property manually.
        ///     This event is in the <see cref="DbLoggerCategory.Scaffolding" /> category.
        /// </summary>
        public static readonly EventId EnumColumnSkippedWarning = MakeScaffoldingId(Id.EnumColumnSkippedWarning);

        /// <summary>
        /// Expression index cannot be scaffolded, expression indices aren't supported and must be added via raw SQL in migrations.
        /// This event is in the <see cref="DbLoggerCategory.Scaffolding" /> category.
        /// </summary>
        public static readonly EventId ExpressionIndexSkippedWarning = MakeScaffoldingId(Id.ExpressionIndexSkippedWarning);

        /// <summary>
        /// Index '{name}' on table {tableName} cannot be scaffolded because it includes a column that cannot be scaffolded (e.g. enum).
        /// </summary>
        public static readonly EventId UnsupportedColumnIndexSkippedWarning = MakeScaffoldingId(Id.UnsupportedColumnIndexSkippedWarning);
        
        /// <summary>
        /// Constraint '{name}' on table {tableName} cannot be scaffolded because it includes a column that cannot be scaffolded (e.g. enum).
        /// </summary>
        public static readonly EventId UnsupportedColumnConstraintSkippedWarning = MakeScaffoldingId(Id.UnsupportedConstraintIndexSkippedWarning);
    }
}
