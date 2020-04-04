using GraphQL;
using System;

namespace FluentValidation
{
    public static class Validators
    {
        private static IRuleBuilderOptions<T, TGlobalId> ValidGlobalId<T, TGlobalId, TId>(this IRuleBuilder<T, TGlobalId> ruleBuilder, Func<TId, bool> isInvalidFunc)
            where TGlobalId : GlobalId<TId>
        {
            return ruleBuilder
                .Must(globalId => !isInvalidFunc(globalId.Id))
                .WithMessage($"Must be a global id of type {typeof(TId).Name} with a non-default value.");
        }

        public static IRuleBuilderOptions<T, IntGlobalId> ValidGlobalId<T>(this IRuleBuilder<T, IntGlobalId> ruleBuilder)
             => ruleBuilder.ValidGlobalId<T, IntGlobalId, int>(id => id <= 0);

        public static IRuleBuilderOptions<T, LongGlobalId> ValidGlobalId<T>(this IRuleBuilder<T, LongGlobalId> ruleBuilder)
             => ruleBuilder.ValidGlobalId<T, LongGlobalId, long>(id => id <= 0);

        public static IRuleBuilderOptions<T, StringGlobalId> ValidGlobalId<T>(this IRuleBuilder<T, StringGlobalId> ruleBuilder)
             => ruleBuilder.ValidGlobalId<T, StringGlobalId, string>(id => string.IsNullOrWhiteSpace(id));

        public static IRuleBuilderOptions<T, GuidGlobalId> ValidGlobalId<T>(this IRuleBuilder<T, GuidGlobalId> ruleBuilder)
             => ruleBuilder.ValidGlobalId<T, GuidGlobalId, Guid>(id => id == default);
    }
}
