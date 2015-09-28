// ReSharper disable All
/********************************************************************************
Copyright (C) MixERP Inc. (http://mixof.org).
This file is part of MixERP.
MixERP is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, version 2 of the License.

MixERP is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with MixERP.  If not, see <http://www.gnu.org/licenses/>.
***********************************************************************************/
using MixERP.Net.DbFactory;
using MixERP.Net.Framework;
using PetaPoco;
using MixERP.Net.Entities.Office;
using Npgsql;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MixERP.Net.Schemas.Office.Data
{
    /// <summary>
    /// Prepares, validates, and executes the function "office.get_income_tax_rate(_office_id integer)" on the database.
    /// </summary>
    public class GetIncomeTaxRateProcedure : DbAccess
    {
        /// <summary>
        /// The schema of this PostgreSQL function.
        /// </summary>
        public override string _ObjectNamespace => "office";
        /// <summary>
        /// The schema unqualified name of this PostgreSQL function.
        /// </summary>
        public override string _ObjectName => "get_income_tax_rate";
        /// <summary>
        /// Login id of application user accessing this PostgreSQL function.
        /// </summary>
        public long _LoginId { get; set; }
        /// <summary>
        /// User id of application user accessing this table.
        /// </summary>
        public int _UserId { get; set; }
        /// <summary>
        /// The name of the database on which queries are being executed to.
        /// </summary>
        public string _Catalog { get; set; }

        /// <summary>
        /// Maps to "_office_id" argument of the function "office.get_income_tax_rate".
        /// </summary>
        public int OfficeId { get; set; }

        /// <summary>
        /// Prepares, validates, and executes the function "office.get_income_tax_rate(_office_id integer)" on the database.
        /// </summary>
        public GetIncomeTaxRateProcedure()
        {
        }

        /// <summary>
        /// Prepares, validates, and executes the function "office.get_income_tax_rate(_office_id integer)" on the database.
        /// </summary>
        /// <param name="officeId">Enter argument value for "_office_id" parameter of the function "office.get_income_tax_rate".</param>
        public GetIncomeTaxRateProcedure(int officeId)
        {
            this.OfficeId = officeId;
        }
        /// <summary>
        /// Prepares and executes the function "office.get_income_tax_rate".
        /// </summary>
        public float Execute()
        {
            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Execute, this._LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the function \"GetIncomeTaxRateProcedure\" was denied to the user with Login ID {LoginId}.", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
            const string query = "SELECT * FROM office.get_income_tax_rate(@0::integer);";
            return Factory.Scalar<float>(this._Catalog, query, this.OfficeId);
        }
    }
}