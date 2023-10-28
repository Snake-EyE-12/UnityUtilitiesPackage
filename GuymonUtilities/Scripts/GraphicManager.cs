using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Guymon.DesignPatterns;
using Guymon.Utilities;
using System.Runtime.InteropServices;
using UnityEngine.UI;

namespace Guymon.Graphics
{
    public class GraphicManager : Singleton<GraphicManager>
    {
        [System.Serializable]
        public class IDGraphic
        {
            public string name;
            public Graphic graphic;
        }
        [SerializeField] private List<IDGraphic> graphics = new List<IDGraphic>();

        /// <summary>
        /// Sets the Graphic to Active
        /// </summary>
        /// <param name="graphicID">Graphic Name</param>
        /// <param name="position">New Position</param>
        /// <param name="rotation">New Rotation</param>
        /// <param name="scale">New Scale</param>
        /// <param name="duration">Total Duration of Active Graphic</param>
        /// <param name="fadeIn">Time of Fade In</param>
        /// <param name="fadeOut">Time of Fade Out</param>
        public void Display(string graphicID, Vector3 position, Quaternion rotation, Vector3 scale, float duration, float fadeIn, float fadeOut) {
            Graphic graphic = Find(graphicID);
            if(graphic == null) return;
            graphic.transform.position = position;
            graphic.transform.rotation = rotation;
            graphic.transform.localScale = scale;
            StartCoroutine(PlayGraphic(graphic, Mathf.Max(duration, fadeIn + fadeOut), fadeIn, fadeOut));
        }
        /// <summary>
        /// Sets the Graphic to Active
        /// </summary>
        /// <param name="graphicID">Graphic Name</param>
        /// <param name="position">New Position</param>
        /// <param name="rotation">New Rotation</param>
        /// <param name="scale">New Scale</param>
        /// <param name="duration">Total Duration of Active Graphic</param>
        public void Display(string graphicID, Vector3 position, Quaternion rotation, Vector3 scale, float duration) {
            Graphic graphic = Find(graphicID);
            if(graphic == null) return;
            graphic.transform.position = position;
            graphic.transform.rotation = rotation;
            graphic.transform.localScale = scale;
            StartCoroutine(PlayGraphic(graphic, duration));
        }
        /// <summary>
        /// Sets the Graphic to Active
        /// </summary>
        /// <param name="graphicID">Graphic Name</param>
        /// <param name="position">New Position</param>
        /// <param name="rotation">New Rotation</param>
        /// <param name="scale">New Scale</param>
        public void Display(string graphicID, Vector3 position, Quaternion rotation, Vector3 scale) {
            Graphic graphic = Find(graphicID);
            if(graphic == null) return;
            graphic.transform.position = position;
            graphic.transform.rotation = rotation;
            graphic.transform.localScale = scale;
            graphic.gameObject.SetActive(true);
        }
        /// <summary>
        /// Sets the Graphic to Active
        /// </summary>
        /// <param name="graphicID">Graphic Name</param>
        /// <param name="position">New Position</param>
        /// <param name="rotation">New Rotation</param>
        /// <param name="duration">Total Duration of Active Graphic</param>
        /// <param name="fadeIn">Time of Fade In</param>
        /// <param name="fadeOut">Time of Fade Out</param>
        public void Display(string graphicID, Vector3 position, Quaternion rotation, float duration, float fadeIn, float fadeOut) {
            Graphic graphic = Find(graphicID);
            if(graphic == null) return;
            graphic.transform.position = position;
            graphic.transform.rotation = rotation;
            StartCoroutine(PlayGraphic(graphic, Mathf.Max(duration, fadeIn + fadeOut), fadeIn, fadeOut));
        }
        /// <summary>
        /// Sets the Graphic to Active
        /// </summary>
        /// <param name="graphicID">Graphic Name</param>
        /// <param name="position">New Position</param>
        /// <param name="rotation">New Rotation</param>
        /// <param name="duration">Total Duration of Active Graphic</param>
        public void Display(string graphicID, Vector3 position, Quaternion rotation, float duration) {
            Graphic graphic = Find(graphicID);
            if(graphic == null) return;
            graphic.transform.position = position;
            graphic.transform.rotation = rotation;
            StartCoroutine(PlayGraphic(graphic, duration));
        }
        /// <summary>
        /// Sets the Graphic to Active
        /// </summary>
        /// <param name="graphicID">Graphic Name</param>
        /// <param name="position">New Position</param>
        /// <param name="rotation">New Rotation</param>
        public void Display(string graphicID, Vector3 position, Quaternion rotation) {
            Graphic graphic = Find(graphicID);
            if(graphic == null) return;
            graphic.transform.position = position;
            graphic.transform.rotation = rotation;
            graphic.gameObject.SetActive(true);
        }
        /// <summary>
        /// Sets the Graphic to Active
        /// </summary>
        /// <param name="graphicID">Graphic Name</param>
        /// <param name="position">New Position</param>
        /// <param name="duration">Total Duration of Active Graphic</param>
        /// <param name="fadeIn">Time of Fade In</param>
        /// <param name="fadeOut">Time of Fade Out</param>
        public void Display(string graphicID, Vector3 position, float duration, float fadeIn, float fadeOut) {
            Graphic graphic = Find(graphicID);
            if(graphic == null) return;
            graphic.transform.position = position;
            StartCoroutine(PlayGraphic(graphic, Mathf.Max(duration, fadeIn + fadeOut), fadeIn, fadeOut));
        }
        /// <summary>
        /// Sets the Graphic to Active
        /// </summary>
        /// <param name="graphicID">Graphic Name</param>
        /// <param name="position">New Position</param>
        /// <param name="duration">Total Duration of Active Graphic</param>
        public void Display(string graphicID, Vector3 position, float duration) {
            Graphic graphic = Find(graphicID);
            if(graphic == null) return;
            graphic.transform.position = position;
            StartCoroutine(PlayGraphic(graphic, duration));
        }
        /// <summary>
        /// Sets the Graphic to Active
        /// </summary>
        /// <param name="graphicID">Graphic Name</param>
        /// <param name="position">New Position</param>
        public void Display(string graphicID, Vector3 position) {
            Graphic graphic = Find(graphicID);
            if(graphic == null) return;
            graphic.transform.position = position;
            graphic.gameObject.SetActive(true);
        }
        /// <summary>
        /// Sets the Graphic to Active
        /// </summary>
        /// <param name="graphicID">Graphic Name</param>
        /// <param name="duration">Total Duration of Active Graphic</param>
        /// <param name="fadeIn">Time of Fade In</param>
        /// <param name="fadeOut">Time of Fade Out</param>
        public void Display(string graphicID, float duration, float fadeIn, float fadeOut) {
            Graphic graphic = Find(graphicID);
            if(graphic == null) return;
            StartCoroutine(PlayGraphic(graphic, Mathf.Max(duration, fadeIn + fadeOut), fadeIn, fadeOut));
        }
        /// <summary>
        /// Sets the Graphic to Active
        /// </summary>
        /// <param name="graphicID">Graphic Name</param>
        /// <param name="duration">Total Duration of Active Graphic</param>
        public void Display(string graphicID, float duration) {
            Graphic graphic = Find(graphicID);
            if(graphic == null) return;
            StartCoroutine(PlayGraphic(graphic, duration));
        }
        /// <summary>
        /// Sets the Graphic to Active
        /// </summary>
        /// <param name="graphicID">Graphic Name</param>
        public void Display(string graphicID) {
            Graphic graphic = Find(graphicID);
            if(graphic == null) return;
            graphic.gameObject.SetActive(true);
        }
        private Graphic Find(string graphicID) {
            foreach(IDGraphic id in graphics) {
                if(id.name.Equals(graphicID)) return id.graphic;
            }
            Guymon.Utilities.Console.Warning("GraphicHandler: Graphic (" + graphicID + ") could not be found");
            return null;
        }
        IEnumerator PlayGraphic(Graphic graphic, float duration, float fadeIn, float fadeOut) {
            float elapsedTime = 0;
            float alpha = 0;
            SpriteRenderer sr;
            MaskableGraphic mg;
            graphic.TryGetComponent<SpriteRenderer>(out sr);
            if(sr != null) {
                alpha = sr.color.a;
            }
            graphic.TryGetComponent<MaskableGraphic>(out mg);
            if(mg != null) {
                alpha = mg.color.a;
            }

            graphic.gameObject.SetActive(true);

            while(elapsedTime < duration) {
                if(sr != null) {
                    if(elapsedTime < fadeIn) sr.color = new Color(sr.color.r, sr.color.g, sr.color. b, Mathf.Lerp(0, alpha, elapsedTime / fadeIn));
                    if(elapsedTime > duration - fadeOut) sr.color = new Color(sr.color.r, sr.color.g, sr.color. b, Mathf.Lerp(0, alpha, (duration - elapsedTime) / (fadeOut)));
                }
                if(mg != null) {
                    if(elapsedTime < fadeIn) mg.color = new Color(mg.color.r, mg.color.g, mg.color. b, Mathf.Lerp(0, alpha, elapsedTime / fadeIn));
                    if(elapsedTime > duration - fadeOut) mg.color = new Color(mg.color.r, mg.color.g, mg.color. b, Mathf.Lerp(0, alpha, (duration - elapsedTime) / (fadeOut)));
                }
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            if(sr != null) {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color. b, alpha);
            }
            if(mg != null) {
                mg.color = new Color(mg.color.r, mg.color.g, mg.color. b, alpha);
            }
            graphic.gameObject.SetActive(false);
        }
        IEnumerator PlayGraphic(Graphic graphic, float duration) {
            
            graphic.gameObject.SetActive(true);

            yield return new WaitForSeconds(duration);

            graphic.gameObject.SetActive(false);
        }
    }
}