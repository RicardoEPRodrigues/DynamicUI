using System;

namespace NEW {

    public enum ShowResult {
        // First time the UI is shown.
        FIRST,
        // The UI was shown.
        OK,
        // The UI wasn't able to be shown.
        FAIL
    }

    public interface IControl {
        /// <summary>
        /// Show this instance.
        /// </summary>
        /// <returns>
        /// <c>ShowResult.FIRST</c> if the UI was shown for the first time;
        /// <c>ShowResult.OK</c> if the UI was shown without a problem;
        /// <c>ShowResult.FAIL</c> if the UI couldn't be shown;
        /// </returns>
        ShowResult Show();

        /// <summary>
        /// This method destroys the instance of the prefab, if that is not
        /// what you want please use <c>Disable()</c>.
        /// </summary>
        void Destroy();

        /// <summary>
        /// Disables this instance.
        /// </summary>
        void Disable();

        /// <summary>
        /// Gets a value indicating whether this instance is visible.
        /// </summary>
        /// <return><c>true</c> if this instance is visible; otherwise, <c>false</c>.</return>
        bool IsVisible();
    }
}

