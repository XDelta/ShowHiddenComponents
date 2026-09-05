using FrooxEngine;
using ResoniteModLoader;

namespace ShowHiddenComponents;

public class ShowHiddenComponents : ResoniteMod {
	internal const string VERSION_CONSTANT = "1.0.0";
	public override string Name => "ShowHiddenComponents";
	public override string Author => "Delta";
	public override string Version => VERSION_CONSTANT;
	public override string Link => "https://github.com/XDelta/ShowHiddenComponents/";

	public override void OnEngineInit() {
		var hiddenCategory = WorkerInitializer.ComponentLibrary.GetSubcategory("Hidden");

		var hiddenTypes = WorkerInitializer.Workers
			.Where(type =>
				typeof(Component).IsAssignableFrom(type) &&
				type.GetCustomAttributes(typeof(CategoryAttribute), true)
					.OfType<CategoryAttribute>()
					.Any(a => a.Paths?.Contains("Hidden") == true));

		foreach (Type type in hiddenTypes) {
			hiddenCategory.AddElement(type);
		}
	}
}
