main areas of concern:

1. repetitive access to application fields such as Product and CompanyData, local variables should be introduced
2. CompanyDataRequest creation is duplicated, it better be extracted in a factory or an extension method
3. IApplicationResult conversion to int also can be extracted to an extension to remove the duplication
