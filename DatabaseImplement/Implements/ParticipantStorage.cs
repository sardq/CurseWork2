using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;
using DatabaseImplement;
using DatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace Contracts.StorageContracts
{
	public class ParticipantStorage : IParticipantStorage
	{
		public List<ParticipantViewModel> GetFullList()
		{
			using var context = new Database();
			return context.Participants
					.Include(x => x.Teacher)
					.Include(x => x.ScientificWork)
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public List<ParticipantViewModel> GetFilteredList(ParticipantSearchModel model)
		{
			using var context = new Database();
			if (!model.Id.HasValue)
			{
				return null;
			}
			return context.Participants
					.Include(x => x.ScientificWork)
					.Include(x => x.Teacher)
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public ParticipantViewModel? GetElement(ParticipantSearchModel model)
		{
			if (model.Id.HasValue)
			{
				return null;
			}
			using var context = new Database();
			return context.Participants
					.Include(x => x.ScientificWork)
				   .Include(x => x.Teacher)
					.FirstOrDefault(x => ((model.Id.HasValue && x.Id == model.Id)))
					?.GetViewModel;
		}

		public ParticipantViewModel? Insert(ParticipantBindingModel model)
		{
			using var context = new Database();
			var newParticipant = Participant.Create(model);
			if (newParticipant == null)
			{
				return null;
			}
			context.Participants.Add(newParticipant);
			context.SaveChanges();
			return newParticipant.GetViewModel;
		}
		public ParticipantViewModel? Update(ParticipantBindingModel model)
		{
			using var context = new Database();
			var participant = context.Participants.Include(x => x.ScientificWork).Include(x => x.Teacher).FirstOrDefault(x => x.Id == model.Id);
			if (participant == null)
			{
				return null;
			}
			participant.Update(model);
			context.SaveChanges();
			return participant.GetViewModel;
		}

		public ParticipantViewModel? Delete(ParticipantBindingModel model)
		{
			using var context = new Database();
			var element = context.Participants.Include(x => x.ScientificWork).Include(x => x.Teacher).FirstOrDefault(rec => rec.Id == model.Id);
			if (element != null)
			{
				context.Participants.Remove(element);
				context.SaveChanges();
				return element.GetViewModel;
			}
			return null;
		}
	}
}
