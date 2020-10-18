## Main areas of concern

1. Repetitive access to application fields such as Product and CompanyData, local variables should be introduced.
2. CompanyDataRequest creation is duplicated, it better be extracted in a factory or an extension method.
3. IApplicationResult conversion to int also can be extracted to an extension to remove the duplication.
4. -1 should be defined as a constant.
5. LoansRequest creation can be moved to BusinessLoans.
