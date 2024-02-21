using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guymon.Components {
    /// <summary>
    /// Allows for Multiple Tags and Tag Comparisons 
    /// </summary>
    public class Tags : MonoBehaviour
    {
        [SerializeField] private List<string> tags = new List<string>();
        /// <summary>
        /// Compares 1 Tag to Object's Tags
        /// </summary>
        /// <param name="tag">Tag to Look for</param>
        /// <returns>Whether the Tag was Found</returns>
        public new bool CompareTag(string tag) {
            return (tags.Contains(tag));
        }
        /// <summary>
        /// Compares Many Tags for Any Matches
        /// </summary>
        /// <param name="anyTag">Tags to Look for</param>
        /// <returns>Whether Any Tag Matched</returns>
        public bool CompareTag(string[] anyTag) {
            for(int i = 0; i < anyTag.Length; i++) {
                for(int j = 0; j < tags.Count; j++) {
                    if(anyTag[i].Equals(tags[j])) return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Compares Many Tags for All Matches
        /// </summary>
        /// <param name="allTags">Tags to Look for</param>
        /// <returns>Whether All Tags were Found</returns>
        public bool CompareTags(string[] allTags) {
            int foundCount = 0;
            for(int i = 0; i < allTags.Length; i++) {
                for(int j = 0; j < tags.Count; j++) {
                    if(allTags[i].Equals(tags[j])) foundCount++;
                }
            }
            return (foundCount == allTags.Length);
        }
        /// <summary>
        /// Get All Object's Tags
        /// </summary>
        /// <returns>String Array of All Tags</returns>
        public string[] GetTags() {
            return tags.ToArray();
        }
        /// <summary>
        /// Add a Tag to Object's Tags
        /// </summary>
        /// <param name="tag">Tag to be Added</param>
        /// <returns>Whether Tag was Successfully Added</returns>
        public bool AddTag(string tag) {
            if(CompareTag(tag)) return false;
            tags.Add(tag);
            return true;
        }
        /// <summary>
        /// Remove a Tag from Object's Tags
        /// </summary>
        /// <param name="tag">Tag to be Removed</param>
        /// <returns>Whether Tag was Successfully Removed</returns>
        public bool RemoveTag(string tag) {
            if(!CompareTag(tag)) return false;
            tags.Remove(tag);
            return true;
        }
    }
}