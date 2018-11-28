using System;
using Open.Domain.Process;

namespace Open.Facade.Process
{
    public static class SuggestionViewModelFactory
    {
        public static SuggestionViewModel Create(DosageObject d, SchemeObject s)
        {
            var v = new SuggestionViewModel()
            {
                ID = d?.DbRecord.ID,
                TypeOfTreatment = d?.DbRecord.TypeOfTreatment,
                Length = s?.DbRecord.Length,
                Amount = s?.DbRecord.Amount,
                Times = s?.DbRecord.Times,
                TimeOfDay = s?.DbRecord.TimeOfDay,
            };
            if (s is null || d is null) return v;
            v.ValidFrom = setNullIfExtremum(d.DbRecord.ValidFrom);
            v.ValidTo = setNullIfExtremum(d.DbRecord.ValidTo);
            return v;
        }
        private static DateTime? setNullIfExtremum(DateTime d)
        {
            if (d.Date >= DateTime.MaxValue.Date) return null;
            if (d.Date <= DateTime.MinValue.AddDays(1).Date) return null;
            return d;
        }
    }
}