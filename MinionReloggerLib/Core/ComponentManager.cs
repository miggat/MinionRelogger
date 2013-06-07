/*****************************************************************************
*                                                                            *
*  MinionReloggerLib 0.x Alpha -- https://github.com/Vipeax/MinionRelogger   *
*  Copyright (C) 2013, Robert van den Boorn                                  *
*                                                                            *
*  This program is free software: you can redistribute it and/or modify      *
*   it under the terms of the GNU General Public License as published by     *
*   the Free Software Foundation, either version 3 of the License, or        *
*   (at your option) any later version.                                      *
*                                                                            *
*   This program is distributed in the hope that it will be useful,          *
*   but WITHOUT ANY WARRANTY; without even the implied warranty of           *
*   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the            *
*   GNU General Public License for more details.                             *
*                                                                            *
*   You should have received a copy of the GNU General Public License        *
*   along with this program.  If not, see <http://www.gnu.org/licenses/>.    *
*                                                                            *
******************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Language;
using MinionReloggerLib.Interfaces;
using MinionReloggerLib.Interfaces.RelogComponents;
using MinionReloggerLib.Logging;

namespace MinionReloggerLib.Core
{
    public class ComponentManager
    {
        private static ComponentManager _instance;

        private readonly List<IRelogComponent> _components;

        protected ComponentManager()
        {
            _components = new List<IRelogComponent>();
        }

        public static ComponentManager Singleton
        {
            get { return _instance ?? (_instance = new ComponentManager()); }
            set { _instance = value; }
        }

        internal List<IRelogComponent> GetComponents()
        {
            return _components;
        }

        internal void AddComponent(IRelogComponent componentToAdd)
        {
            _components.Add(componentToAdd);
            Logger.LoggingObject.Log(ELogType.Info,
                                     LanguageManager.Singleton.GetTranslation(
                                         ETranslations.ComponentManagerAddedComponent), componentToAdd.GetName());
        }

        public void EnableComponent(string componentToEnable)
        {
            IRelogComponent first = _components.FirstOrDefault(c => c.GetName() == componentToEnable);
            if (first != null)
            {
                first.Enable();
                first.OnEnable();
                Logger.LoggingObject.Log(ELogType.Info,
                                         LanguageManager.Singleton.GetTranslation(
                                             ETranslations.ComponentManagerEnableComponent), componentToEnable);
            }
        }

        public void DisableComponent(string componentToDisable)
        {
            IRelogComponent first = _components.FirstOrDefault(c => c.GetName() == componentToDisable);
            if (first != null)
            {
                first.Disable();
                first.OnDisable();
                Logger.LoggingObject.Log(ELogType.Info,
                                         LanguageManager.Singleton.GetTranslation(
                                             ETranslations.ComponentManagerDisableComponent), componentToDisable);
            }
        }

        public void LoadComponents()
        {
            foreach (IRelogComponent relogComponent in _components)
            {
                relogComponent.OnUnload();
            }

            _components.Clear();

            AddComponent(new BreakComponent());
            AddComponent(new LaunchDelayComponent());
            AddComponent(new RestartDelayComponent());
            AddComponent(new IPCheckComponent());
            AddComponent(new ScheduleComponent());

            try
            {
                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Plugins"))
                    return;
                var di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\\Plugins");
                foreach (FileInfo fi in di.GetFiles())
                {
                    if (fi.Extension.ToLower() == ".dll")
                    {
                        try
                        {
                            Assembly assembly = Assembly.LoadFrom(fi.FullName);
                            if (assembly != null)
                            {
                                String fName = fi.Name.Replace(fi.Extension, String.Empty);
                                IRelogComponent toRemove = _components.FirstOrDefault(c => c.GetName() == fName);
                                if (toRemove != null)
                                    _components.Remove(toRemove);
                                foreach (Type t in assembly.GetTypes())
                                {
                                    if (t.GetInterface("IRelogComponent") != null && t.IsClass)
                                    {
                                        object obj = Activator.CreateInstance(t);
                                        var component = (IRelogComponent) obj;
                                        AddComponent(component);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.LoggingObject.Log(ELogType.Error, ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LoggingObject.Log(ELogType.Error, ex.Message);
            }

            foreach (IRelogComponent relogComponent in _components)
            {
                EnableComponent(relogComponent.GetName());
                relogComponent.OnLoad();
            }
        }
    }
}