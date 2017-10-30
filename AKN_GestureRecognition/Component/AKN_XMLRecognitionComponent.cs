using unityengine;
using system.collections;
using akene.ai.akn_gesturerecognition;

using system.collections.generic;

public class akn_xmlrecognitioncomponent : monobehaviour
{

    public list<gameobject> m_sourceobject;

    public list<float> m_gesturerecogntion;



    akn_gesturerecognition _m_gesturerecognition;




    public gameobject m_kinectgameobject;
    public akn_kinectcomponent m_kinectcomponent;
    public list<string> m_xmllist = new list<string> { "salut1.xml", "salut2.xml", "salut3.xml", "salut4.xml", "salut5.xml", "salut6.xml", "salut7.xml", "salut8.xml", "salut9.xml", "salut10.xml", "salut11.xml" };

    //,"serrerlamain1.xml","serrerlamain2.xml","serrerlamain3.xml","serrerlamain4.xml","serrerlamain5.xml","serrerlamain6.xml",
    //"brascroises1.xml","brascroises2.xml","brascroises3.xml","brascroises4.xml","brascroises5.xml","brascroises6.xml","brascroises7.xml",};


    akn_readxmlfile _m_xmlfilelist;
    public list<float> m_output = new list<float> { 0, 0, 0 };

    private list<gameobject> _m_input = new list<gameobject>();

    public string m_posename = "salut";
    public list<string> m_posenamelist = new list<string>();//{"salut" , "serrerlamain", "brascroises"};
    public list<bool> m_indicetolearn = new list<bool> { false, false, false, false, false, false, false, false, false, false, false };
    //, false , false , false , false , false , false
    //, false , false , false , false , false , false , false};
    // public bool m_learn = false;
    public bool m_init = false;
    public bool m_think = false;
    akn_gesturerecognition _m_gesturerecognition;
    akn_skeletonjoints _m_joints;
    void awake()
    {
        if (m_kinectgameobject != null)
        {
            m_kinectcomponent = m_kinectgameobject.getcomponent<akn_kinectcomponent>();
        }
        else
        {
            debug.log("you must define m_kinectgameobject");
        }
    }
    // use this for initialization
    void start()
    {
        _m_input.clear();
        _m_input = mmakeinput(m_kinectcomponent);
        if (_m_input != null)
        {
            _m_gesturerecognition = new akn_gesturerecognition(_m_input, m_output);
        }
        else
        {
            debug.log("error in define akn_gesturerecognition");
        }
    }

    // update is called once per frame
    void update()
    {
        int i = 0;
        foreach (bool m_learn in m_indicetolearn)
        {
            // debug.log("i = " + i);
            if (m_learn)
            {
                _m_input.clear();
                if (m_posename == "")
                {
                    m_posename = "pose" + m_posenamelist.count + 1;
                }
                m_posenamelist.add(m_posename);

                _m_xmlfilelist = new akn_readxmlfile(m_xmllist[i]);
                _m_xmlfilelist.mread();
                _m_xmlfilelist.mmakegameobject();
                _m_input = _m_xmlfilelist.m_gameobjectlist;
                _m_gesturerecognition.maddpose(m_posenamelist.count, _m_input);

                m_indicetolearn[i] = false;

                // debug.log("pose "+i+" learned");
                return;
            }
            i++;

        }
        if (m_init)
        {
            _m_gesturerecognition.minit();
            debug.log("init");
            m_init = false;
            return;
        }
        if (m_think)
        {
            _m_input.clear();
            _m_input = mmakeinput(m_kinectcomponent);
            m_output = _m_gesturerecognition.mrecognize(_m_input);
            m_think = false;
        }
    }
    public list<gameobject> mmakeinput(akn_kinectcomponent _kinectcomponent)
    {
        list<gameobject> listgo = new list<gameobject>();
        _m_joints = new akn_skeletonjoints(_kinectcomponent);
        foreach (keyvaluepair<string, gameobject> kvp in _m_joints.m_joints)
        {
            listgo.add(kvp.value);
        }
        //debug.log("input kinect ");
        return listgo;
    }
}
