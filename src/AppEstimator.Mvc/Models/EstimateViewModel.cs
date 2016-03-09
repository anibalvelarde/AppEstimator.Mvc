using AppEstimator.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppEstimator.Mvc.Models
{
    public class EstimateViewModel
    {
        private readonly Estimate _model;
        public EstimateViewModel(Estimate model)
        {
            if (model == null) { throw new ArgumentNullException("Model cannot be null"); }
            _model = model;
            //////////////////////////////////////////////
            // TODO:  Take care of this problme in the Business Library
            if (_model.Actors == null) { _model.Actors = new List<Actor>(); }
            if (_model.UseCases == null) { _model.UseCases = new List<UseCase>(); }
            //////////////////////////////////////////////
        }

        public Estimate CurrentEstimate
        {
            get { return _model; }
        }

        public bool IsMissingActors { get { return this.CurrentEstimate.Actors.Count.Equals(0); } }
        public bool IsMissingUseCases { get { return this.CurrentEstimate.UseCases.Count.Equals(0); } }
        public bool IsMissingTechFacs { get { return this.CurrentEstimate.TechnicalFactors.Count.Equals(0); } }
        public bool IsMissingEnvFacs { get { return this.CurrentEstimate.EnvironmentalFactors.Count.Equals(0); } }

        public bool IsSetupCorrectly
        {
            get
            {
                bool isCorrect = true;
                if (this.IsMissingActors) { return false; }
                if (this.IsMissingUseCases) { return false; }
                if (this.IsMissingTechFacs) { return false; }
                if (this.IsMissingEnvFacs) { return false; }
                return isCorrect;
            }
        }
    }
}