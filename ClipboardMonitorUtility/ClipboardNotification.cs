namespace ClipboardMonitor.Utilities
{
    using System;

    public class ClipboardNotification
    {
        private static NotificationForm _form = new NotificationForm();

        /// <summary>
        /// Agrega un EventHandler al evento ClipboardUpdate.
        /// </summary>
        /// <param name="eventHandler">EventHandler a agregar/quitar.</param>
        /// <param name="add">En caso de ser falso, el EventHandler será quitado.</param>
        public static void AddEventHandler(EventHandler<ClipboardUpdateEventArgs> eventHandler, bool add = true)
        {
            if (add)
            {
                _form.ClipboardUpdate += eventHandler;
            }
            else
            {
                _form.ClipboardUpdate -= eventHandler;
            }
        }
    }
}
