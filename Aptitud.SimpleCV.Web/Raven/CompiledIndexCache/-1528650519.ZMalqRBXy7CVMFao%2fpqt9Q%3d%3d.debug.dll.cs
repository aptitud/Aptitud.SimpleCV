using Raven.Abstractions;
using Raven.Database.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;
using Raven.Database.Linq.PrivateExtensions;
using Lucene.Net.Documents;
using System.Globalization;
using System.Text.RegularExpressions;
using Raven.Database.Indexing;


public class Index_Temp_2fUserLogins_2fByProviders_IdentityKey : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Temp_2fUserLogins_2fByProviders_IdentityKey()
	{
		this.ViewText = @"from doc in docs.UserLogins
from docProvidersItem in ((IEnumerable<dynamic>)doc.Providers).DefaultIfEmpty()
select new { Providers_IdentityKey = docProvidersItem.IdentityKey }";
		this.ForEntityNames.Add("UserLogins");
		this.AddMapDefinition(docs => 
			from doc in docs
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "UserLogins", System.StringComparison.InvariantCultureIgnoreCase)
			from docProvidersItem in ((IEnumerable<dynamic>)doc.Providers).DefaultIfEmpty()
			select new {
				Providers_IdentityKey = docProvidersItem.IdentityKey,
				__document_id = doc.__document_id
			});
		this.AddField("Providers_IdentityKey");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("IdentityKey");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("IdentityKey");
		this.AddQueryParameterForReduce("__document_id");
	}
}
