using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yayen.Assignment1.Framework.MonoGameBase;
using Yayen.Assignment1.Framework.Scenes.Base;
using static System.Formats.Asn1.AsnWriter;

namespace Yayen.Assignment1.Framework.Scenes
{
    /// <summary>
    /// The system to manage scenes
    /// </summary>
    public class SceneSystem
    {
        public Scene previousScene;
        List<Scene> _scenes = new();
        /// <summary>
        /// I made _loadedScenes a list to be able to expand it to use multiple scenes at the same time in the future. for now the only interesting index is 0 for the currently active scene.
        /// </summary>
        List<Scene> _loadedScenes = new();
        ContentManager _content;
        Game1 _game1;

        #region Constructors
        public SceneSystem(ContentManager content, Game1 game1)
        {
            _content = content;
            _game1 = game1;
        }
        #endregion

        /// <summary>
        /// Call to update all active scenes int SceneSystem. As of now only one scene.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < _loadedScenes.Count; i++)
            {
                _loadedScenes[i].Update(gameTime, _game1);
            }
        }

        /// <summary>
        /// Call to draw all active scenes. As of now only one scene.
        /// </summary>
        /// <param name="pSpriteBatch">SpriteBatch to use when drawing.</param>
        public void Draw(SpriteBatch pSpriteBatch)
        {
            for (int i = 0; i < _loadedScenes.Count; i++)
            {
                _loadedScenes[i].Draw(pSpriteBatch);
            }
        }

        /// <summary>
        /// Add scene to be managed by SceneSystem
        /// </summary>
        /// <param name="scene"></param>
        public void AddScene(Scene scene)
        {
            _scenes.Add(scene);
            scene.ResetScene(_content, _game1);
            SwitchScene(scene);
        }

        /// <summary>
        /// Switch the current active scene with scene on index.
        /// </summary>
        /// <param name="index"></param>
        public void SwitchScene(int index)
        {
            _loadedScenes.Clear();
            _loadedScenes.Add(_scenes[index]);
            for (int i = 0; i < _loadedScenes.Count; i++) _loadedScenes[i].EnterScene();
        }
        /// <summary>
        /// Switch the current active scene with scene by name.
        /// </summary>
        /// <param name="name"></param>
        public void SwitchScene(string name)
        {
            Scene sceneToLoad = GetSceneByName(name);
            if (sceneToLoad == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: Scene with name \"{name}\" not found");
                Console.ResetColor();
                return;
            }
            _loadedScenes.Clear();
            _loadedScenes.Add(sceneToLoad);
            for (int i = 0; i < _loadedScenes.Count; i++) _loadedScenes[i].EnterScene();
        }

        /// <summary>
        /// Switch current scene with scene by reference.
        /// </summary>
        /// <param name="scene"></param>
        public void SwitchScene(Scene scene)
        {
            _loadedScenes.Clear();
            _loadedScenes.Add(scene);
            for (int i = 0; i < _loadedScenes.Count; i++) _loadedScenes[i].EnterScene();
        }

        /// <summary>
        /// Switch scene with next scene index.
        /// </summary>
        public void NextScene()
        {
            Scene currentScene = _loadedScenes[0];
            SwitchScene(_scenes.IndexOf(currentScene) + 1);
        }
        /// <summary>
        /// Get scene by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Scene GetSceneByName(string name)
        {
            // Search for scene by name and return
            for (int i = 0; i < _scenes.Count; i++)
            {
                if (_scenes[i].SceneName == name)
                {
                    return _scenes[i];
                }
            }
            // If not found, return null
            return null;
        }
        /// <summary>
        /// Get next scene in scenes list.
        /// </summary>
        /// <returns></returns>
        public Scene GetNextScene()
        {
            Scene currentScene = _loadedScenes[0];
            return _scenes[_scenes.IndexOf(currentScene) + 1];
        }

        /// <summary>
        /// Reset scene by index.
        /// </summary>
        /// <param name="index"></param>
        public void ResetScene(int index)
        {
            _scenes[index].ResetScene(_content, _game1);
        }

        /// <summary>
        /// Reset scene by name.
        /// </summary>
        /// <param name="name"></param>
        public void ResetScene(string name)
        {
            Scene sceneToReset = GetSceneByName(name);
            if (sceneToReset == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: Scene with name \"{name}\" not found");
                Console.ResetColor();
                return;
            }
            sceneToReset.ResetScene(_content, _game1);
        }

        /// <summary>
        /// Reset scene by references.
        /// </summary>
        /// <param name="scene"></param>
        public void ResetScene(Scene scene)
        {
            scene.ResetScene(_content, _game1);
        }

        /// <summary>
        /// Get currently loaded scene.
        /// </summary>
        /// <returns></returns>
        public Scene GetScene()
        {
            return _loadedScenes[0];
        }


    }
}
