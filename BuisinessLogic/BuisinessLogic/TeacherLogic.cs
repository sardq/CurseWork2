using Contracts.BindingModels;
using Contracts.BusinessLogicContracts;
using Contracts.SearchModels;
using Contracts.StorageContracts;
using Contracts.ViewModels;
using DataModels.Enums;
using Microsoft.Extensions.Logging;

namespace BuisinessLogic.BusinessLogic
{
	public class TeacherLogic : ITeacherLogic
	{
		private readonly ILogger _logger;

		private readonly ITeacherStorage _teacherStorage;

		public TeacherLogic(ILogger<TeacherLogic> logger, ITeacherStorage teacherStorage)
		{
			_logger = logger;
			_teacherStorage = teacherStorage;
		}

		public List<TeacherViewModel>? ReadList(TeacherSearchModel? model)
		{
			_logger.LogInformation("ReadList.FullName:{FullName} Id:{Id}", model?.FullName, model?.Id);
			var list = model == null ? _teacherStorage.GetFullList() : _teacherStorage.GetFilteredList(model);
			if (list == null)
			{
				_logger.LogWarning("ReadList return null list");
				return null;
			}
			_logger.LogInformation("ReadList. Count:{Count}", list.Count);
			return list;
		}

		public TeacherViewModel? ReadElement(TeacherSearchModel model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			_logger.LogInformation("ReadElement.FullName:{FullName} Id:{Id}", model.FullName, model.Id);
			var element = _teacherStorage.GetElement(model);
			if (element == null)
			{
				_logger.LogWarning("ReadElement element not found");
				return null;
			}
			_logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
			return element;
		}
		public TeacherCardViewModel? ReadCard(TeacherSearchModel model)
		{
			if (model == null)
				throw new ArgumentNullException(nameof(model));

			_logger.LogInformation("Read Teacher card, Id: {Id}", model.Id);

			var teacher = _teacherStorage.GetElement(model);
			if (teacher == null)
			{
				_logger.LogWarning("Teacher with Id {Id} not found", model.Id);
				return null;
			}

			return new TeacherCardViewModel
			{
				Id = teacher.Id,
				FullName = teacher.FullName,
				AcademicDegree = teacher.AcademicDegree,
				Position = teacher.Position,
				Category = teacher.Category,
				Rate = teacher.Rate,
				DepartmentId = teacher.DepartmentId
			};
		}
		public bool Create(TeacherBindingModel model)
		{
			CheckModel(model);
			if (_teacherStorage.Insert(model) == null)
			{
				_logger.LogWarning("Insert operation failed");
				return false;
			}
			return true;
		}

		public bool Update(TeacherBindingModel model)
		{
			CheckModel(model);
			if (_teacherStorage.Update(model) == null)
			{
				_logger.LogWarning("Update operation failed");
				return false;
			}
			return true;
		}

		public bool Delete(TeacherBindingModel model)
		{
			CheckModel(model, false);
			_logger.LogInformation("Delete. Id:{Id}", model.Id);
			if (_teacherStorage.Delete(model) == null)
			{
				_logger.LogWarning("Delete operation failed");
				return false;
			}
			return true;
		}

		private void CheckModel(TeacherBindingModel model, bool withParams = true)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			if (!withParams)
			{
				return;
			}
			if (string.IsNullOrEmpty(model.FullName))
			{
				throw new ArgumentNullException("Нет ФИО преподавателя", nameof(model.FullName));
			}
			if (model.Rate < 0)
			{
				throw new ArgumentException("Неправильный формат ставки", nameof(model.Rate));
			}
			if (model.Category == TeacherCategoryEnum.None)
			{
				throw new ArgumentException("Нет категории сотрудника", nameof(model.Category));
			}
			if (model.AcademicDegree == AcademicDegreeEnum.None)
			{
				throw new ArgumentException("Нет научной степени сотрудника", nameof(model.AcademicDegree));
			}
			if (model.Position == TeacherPositionEnum.None)
			{
				throw new ArgumentException("Нет должности сотрудника", nameof(model.Position));
			}
			_logger.LogInformation("Teacher. FullName:{FullName}. Rate:{Rate}. Category:{Category}. Position:{Position}.", model.FullName, model.Rate, model.Category, model.AcademicDegree, model.Position);
			var element = _teacherStorage.GetElement(new TeacherSearchModel
			{
				FullName = model.FullName,

			});
			if (element != null && element.Id != model.Id)
			{
				throw new InvalidOperationException("Научная работа с такими данными уже есть");
			}
		}
	}
}
