using HousesPeru.DB;
using HousesPeru.Models;
using HousesPeru.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousesPeru.services
{
    public interface IPlanService
    {
        IEnumerable<Plan> getPlans(); 
        Plan getPlanById(int id);
        PlanViewModel FechaFinPlan(int idPlan, DateTime FechaInicio);
    }
    public class PlanService:IPlanService
    {
        HousesInPeruContext _db;
        public PlanService(HousesInPeruContext db) {
            this._db = db;
        }

        public Plan getPlanById(int id)
        {
            var plan = _db.Plans.Where(x => x.Id == id).FirstOrDefault();
            return plan;
        }
        public PlanViewModel FechaFinPlan(int idPlan, DateTime FechaInicio) {
            var Plan = new PlanViewModel();
            if (idPlan==1) {
                Plan.FechaFin = FechaInicio.AddMonths(1);
            }
            if (idPlan==2) {
                Plan.FechaFin = FechaInicio.AddMonths(6);
            }
            if (idPlan==3) {
                Plan.FechaFin = FechaInicio.AddYears(1);
            }
            return Plan;
            
        }
        public IEnumerable<Plan> getPlans()
        {
            var plans=_db.Plans.ToList();
            return plans;
        }
    }

 
}