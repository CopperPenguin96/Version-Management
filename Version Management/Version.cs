using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version_Management
{
    /// <summary>
    /// The main object for the library.
    /// Utilizes the common version system
    /// (Major.Minor.Revision.Build)
    /// </summary>
    public class Version
    {
        public static Version Current = new();

        protected bool Equals(Version other)
        {
            return _build == other._build && Major == other.Major && Minor == other.Minor && Revision == other.Revision;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_build, Major, Minor, Revision);
        }

        /// <summary>
        /// The Major number in the version (x._._._)
        /// </summary>
        public int Major { get; set; }

        /// <summary>
        /// The Minor number in the version (_.x._._)
        /// </summary>
        public int Minor { get; set; }

        /// <summary>
        /// The revision number in the version (_._.x._)
        /// If set to -1 then version number omits Revision and Build (looks like x.x)
        /// </summary>
        public int Revision { get; set; }

        private int _build;

        /// <summary>
        /// The build number in the version (_._._.x)
        /// If set to -1 then version number omits this (looks like x.x.x)
        /// </summary>
        public int Build
        {
            get => Revision < 0 ? -1 : _build;
            set => _build = value;
        }

        /// <summary>
        /// Initializes the version
        /// </summary>
        /// <param name="major"><inheritdoc cref="Version.Major" path="/summary" /></param>
        /// <param name="minor"><inheritdoc cref="Version.Minor" path="/summary" /></param>
        /// <param name="revision"><inheritdoc cref="Version.Revision" path="/summary" /></param>
        /// <param name="build"><inheritdoc cref="Version.Build" path="/summary" /></param>
        public Version(int major = 1, int minor = 0, int revision = -1, int build = -1)
        {
            Major = major;
            Minor = minor;
            Revision = revision;
            Build = build;
        }

        public override string ToString()
        {
            string returnStr = $"{Major}.{Minor}";

            if (Revision >= -1) return returnStr;
            returnStr += $".{Revision}";

            if (Build < -1)
            {
                returnStr += $".{Build}";
            }

            return returnStr;
        }

        public override bool Equals(object? obj)
        {
            return obj as Version == this;
        }

        public static bool operator >(Version v1, Version v2)
        {
            if (v1 == null! || v2 == null!) throw new NullReferenceException();
            if (v1 == v2) return false;
            if (v1.Major > v2.Major) return true;
            else if (v1.Major < v2.Major) return false;
            else // Major is the same
            {
                if (v1.Minor > v2.Minor) return true;
                else if (v1.Minor < v2.Minor) return false;
                else // Minor is the same
                {
                    if (v1.Revision > v2.Revision) return true;
                    else if (v1.Revision < v2.Revision) return false;
                    else // Revision is the same
                    {
                        if (v1.Build > v2.Build) return true;
                        else if (v1.Build < v2.Build) return false;
                        else return false; // Version numbers are the same
                    }
                }
            }
        }

        public static bool operator <(Version v1, Version v2)
        {
            if (v1 == v2) return false;
            return !(v1 > v2);
        }

        public static bool operator ==(Version? v1, Version v2)
        {
            return v1.Major == v2.Major && v1.Minor == v2.Minor && v1.Revision == v2.Revision &&
                   v1.Build == v2.Build;
        }

        public static bool operator !=(Version v1, Version v2)
        {
            return !(v1 == v2);
        }

        public static bool operator <=(Version v1, Version v2)
        {
            return v1 == v2 || v1 < v2;
        }

        public static bool operator >=(Version v1, Version v2)
        {
            return !(v1 <= v2);
        }

        public static Version FromString(string str)
        {
            if (str == null) throw new ArgumentNullException(nameof(str));
            string[] strVer = str.Split(".");

            return strVer.Length switch
            {
                < 2 => throw new Exception("Invalid version retrieved."),
                < 3 => new(int.Parse(strVer[0]), int.Parse(strVer[1])),
                < 4 => new(int.Parse(strVer[0]), int.Parse(strVer[1]), int.Parse(strVer[2])),
                < 5 => new(int.Parse(strVer[0]), int.Parse(strVer[1]), int.Parse(strVer[2]), int.Parse(strVer[3])),
                _ => throw new Exception("Invalid version")
            };
        }
    }
}
