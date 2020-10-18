## Main areas of concern

1. Repetitive access to application fields such as Product and CompanyData, local variables should be introduced.
2. CompanyDataRequest creation is duplicated, it better be extracted in a factory or an extension method.
3. IApplicationResult conversion to int also can be extracted to an extension to remove the duplication.
4. -1 should be defined as a constant.
5. LoansRequest creation can be moved to BusinessLoans.

## Additional thoughts

- A more complex refactoring can be done to simplify the addition of new products & services.
- An intermediate "submitter" can be introduced, which will do the following:
    - Accept the product.
    - Send the application for it.
    - Process the result and return it.
- The ProductApplicationService then can be configured with mappings [product type] => [submitter].
- After that, the ProductApplicationService doesn't have to be changed to introduce a new product. The new submitter must be defined & registered as a new mapping.
- See "Submitters" folder for a draft.
- Mappings can be configured in a "SubmitterMap" class.
- "ProductSubmissionService" is what the resulting generic service would look like.
- The example of configuration can be seen in "ProductSubmissionServiceFactory" which has the same constructor as the original service and all the configuration is done in it instead of the original service. This configuration can be moved to some bootstrapping code of the application. Anyway the mapping and the actual implementations of submissions are separated even using this factory.
