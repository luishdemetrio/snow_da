# Learn how to build a Declarative Agent via Copilot Studio to consume ServiceNow Graph Connectors and REST APIs


In this hands-on lab, you will dive into the world of automation and integration by using Copilot Studio to create a Declarative Agent tailored for ServiceNow interactions. Here's what you'll learn:

* **Building a Declarative Agent in Copilot Studio:** Understand the fundamentals of setting up and configuring a Declarative Agent specifically designed to interact seamlessly with ServiceNow.

* **Leveraging ServiceNow Graph Connectors:** You'll explore how to integrate your agent with ServiceNow's KnowledgeBase and Catalog connectors. This will enable your agent to fetch and manage knowledge articles and service catalog items directly from ServiceNow, enhancing its capability to provide precise, context-aware responses or actions.

* **Using a SharePoint Site as Knowledge Base**: Discover how to integrate a SharePoint site as a knowledge base for your agent. This includes steps to add the site, provide a detailed description, and verify the integration, enabling your agent to retrieve and utilize information from SharePoint effectively.

* **Consuming ServiceNow REST APIs with Actions:** Gain hands-on experience in using Actions within Copilot Studio to interact with ServiceNow's REST APIs. This includes learning how to make authenticated API calls to retrieve, update, or create data in ServiceNow, thus extending the functionality of your Declarative Agent.

* **Demonstrating Complex Prompts:** Finding a Spreadsheet, Retrieving an Incident, and Creating a New Incident

* **Setting Up Email Communication:** Learn how to configure your agent to send emails. This skill will allow your agent to notify users or administrators based on certain triggers or workflow outcomes within ServiceNow, ensuring smooth communication and workflow management.

By the end of this lab, you'll have a functional Declarative Agent that can interact with ServiceNow to manage knowledge, service requests, and automate notifications, thereby enhancing productivity and user experience in your organization's ServiceNow environment.


Here's a refined agenda for your hands-on lab, ensuring a logical progression through the learning process:

## Agenda:

1. **Introduction to Declarative Agents in Copilot Studio**
 * Overview of Copilot for Microsoft 365
 * Overview of Declarative Agents
 * Overview of Copilot Studio
 
2. **Creating a new Declarative Agent in Copilot Studio**
 * Getting Started with Copilot Studio
 * Consuming ServiceNow Graph Connectors
 * Consuming SharePoint site
 * Consuming ServiceNow REST APIs
 * Email Integration with Copilot Studio
 
3. Wrap-up
* Review of key concepts covered
* Next steps and further learning resources

## 1. Introduction to Declarative Agents in Copilot Studio
 
### Overview of Copilot for Microsoft 365

With Copilot for Microsoft 365, we have access to both the large language model (LLM) and the semantic index, which allows us to leverage a vast amount of information and context. The semantic index is a sophisticated map of your personal and company data, identifying relationships and making important connections within your data. This includes indexing emails, calendar events, Teams chats, and files stored in OneDrive and SharePoint. This helps Copilot understand the intent behind user prompts and retrieve the most relevant information from your organization's content. 

![](images/copilotform365.png)


However, when working with declarative agents, we need to explicitly define what resources we want to use through graph connectors and actions. This approach ensures that the agents are tailored to specific tasks and domains, making them highly specialized and effective. 

### Overview of Declarative Agents

[Copilot Declarative Agents](https://learn.microsoft.com/en-us/microsoft-365-copilot/extensibility/overview-declarative-agent) are a feature of Microsoft 365 Copilot that allow users to create customized agents tailored to specific business needs. These agents are built using the Copilot foundation, which means developers do not need to create anything from scratch. Instead, they can leverage the existing infrastructure, foundation models, and trusted AI services that power Microsoft 365 Copilot. Declarative agents can be designed to perform a variety of tasks, such as automating repetitive processes, providing real-time customer support, or enhancing internal workflows by integrating with enterprise data from sources like SharePoint and Microsoft Graph.

![](images/bizchatagents3.png)

One of the key benefits of declarative agents is their ability to provide consistent and personalized experiences for users. They can be easily created using tools like Copilot Studio, which offers a user-friendly interface for building and configuring agents. Once deployed, these agents can be integrated into various Microsoft 365 applications, such as Teams, SharePoint, and BizChat, allowing users to interact with them seamlessly. By optimizing collaboration and increasing productivity, declarative agents help organizations streamline their operations and improve overall efficiency.

![](images/snowking.png)

>When working with declarative agents, we need to explicitly define what resources we want to use through graph connectors and actions. This approach ensures that the agents are tailored to specific tasks and domains, making them highly specialized and effective. 

**By creating a declarative agent, we don't have access to the full semantic index but just to the parts accessed via the graph connectors that were defined**. This is because declarative agents are designed to be specialists, focusing on specific tasks or domains. This allows the agent to access relevant enterprise data and improve its responses. Additionally, we can provide real-time information to the agent via actions or even through Internet web searches. This ensures the agent stays updated and relevant, delivering accurate and timely responses based on the most current data available.

![](images/agentoverview.png)

To achieve this specialization, we define a persona and provide detailed instructions for the agent, ensuring it can perform its designated functions effectively and consistently. By doing so, we create agents that are highly focused and capable of delivering precise and relevant responses based on their defined scope that meets specific business needs.


### Overview of Copilot Studio

[Copilot Studio](https://www.microsoft.com/en-us/microsoft-copilot/microsoft-copilot-studio?msockid=27a6f47d0a736b181efde6e60b676a8d) is Microsoft's innovative platform designed for the creation, customization, and deployment of AI agents that extend the functionality of Copilot. It empowers users to build intelligent assistants tailored to specific business processes or integration needs without requiring deep coding knowledge. Through an intuitive interface, users can define agents using declarative logic, allowing them to specify desired outcomes rather than coding each step. This approach leverages AI, including large language models, to interpret user intent and automate tasks, from simple data retrievals to complex workflow orchestrations. Copilot Studio is your gateway to enhancing productivity by crafting AI solutions that integrate seamlessly with Microsoft's suite of applications and beyond.

![](images/copilotstudio.png)


## 2. Creating a new Declarative Agent in Copilot Studio

### Getting Started with Copilot Studio

1. In a new browser tab, go to https://copilotstudio.microsoft.com and sign in with your credentials.

2. On the left pane, select **Agents**.

3. Select **Copilot for Microsoft 365**.

![](images/newagent.png)

4. In the **Agents** section, select **+Add** to create a new agent:

![](images/addagent.png)

5. Click on **Skip to Configuration** to bypass the guided setup and jump directly to the configuration page.

![](images/skiptoconfigure.png)

6. **Name Your Agent:** In the configuration page, you'll see a field labeled **Name**. Enter a descriptive and unique name for your agent. The name should clearly reflect the purpose of the agent and be easy to remember. For example, as our agent is designed to assist with ServiceNow, we can name it **ServiceNow Assistant**.

![](images/nameyouragent.png)

7. **Change the Icon**: Click on the **Change Icon** button to open the icon customization options.

![](images/changeicon.png)

 a. In the pop-up window that appears, click on **Change Icon** again.
 
 b. Navigate to the file location C:\lab\images and select the file **snowlogo.png** to upload it as the new icon for your agent.
 
 c. To modify the background color, click on **Change Background Color** within the same pop-up window.
 
 d. Choose a color that complements the icon and visually represents the agent's purpose.
 
 ![](images/iconcolor.png)
 
 e. After making these changes, click **Save** to apply the new icon and background color.

8. **Provide a Description**: Below the name field, you'll find a section for the agent's description. This is where you provide a brief overview of what the agent does. The description should be concise yet informative, giving users a clear understanding of the agent's capabilities. For this agent:

```plaintext
This agent is a specialist designed to assist users in efficiently retrieving information from ServiceNow Knowledge Management and ServiceNow Service Catalog. Additionally, this agent allows users to get real-time updates on incidents and create new incidents directly within the ServiceNow platform.
```

![](images/agentdescription.png)


9. **Add Instructions**: Next, you'll need to provide instructions for your agent. These instructions guide the agent's behavior and responses. Be specific about what the agent should do and how it should interact with users. For our agent, provide the following instructions:

```plaintext

1. **Greeting and Introduction:**
   - Greet users in a professional manner.
   - Introduce yourself as the Snow Assistant.
   - Offer to help users with Snow services.

2. **Role and Responsibilities:**
   - You are a ServiceNow specialist.
   - Your primary responsibility is to assist users in obtaining information from ServiceNow Knowledge Management and ServiceNow Service Catalog.

3. **Scope of Responses:**
   - Snow Assistant should only respond to questions related to ServiceNow graph connectors and plugins.
   - Do not provide information based on the internal language model.

4. **Handling Incomplete Information:**
   - If you cannot proceed with an answer, respond with: "I couldn't find any specific information about that. If there's anything else I can assist you with, please let me know!"
   - Exclude any general knowledge or information that is not explicitly provided within the declared data sources.
   - Do not utilize the base knowledge base of the LLM for generating responses.

5. **Avoiding Hallucination:**
   - If you don't have information to share, do not hallucinate.
   - Always answer with: "Sorry, I can't answer your question. Please let me know if I can assist you with anything else."

6. **Adherence to Instructions:**
   - Strictly adhere to these instructions.
   - Ensure that all responses are aligned with the specified context limitations.

```

![](images/agentinstructions.png)

> Currently, the agent is instructed not to rely on the internal language model (LLM) for generating responses. Instead, the agent should exclusively use the specified knowledge base that we will define later.


10. **Create Starter Prompts**: Starter prompts are predefined questions or topics that help users get started with the agent. These prompts can be added in the "Starter Prompts" section. Think about common tasks or questions users might have and create prompts accordingly. For example, "What are the upcoming deadlines for the project?" or "Assign a new task to John."

a. Click on **+ Add starter prompts** to add your predefined questions or topics.

![](images/addstarterprompts.png)

b. Add the following one to retrieve the information from ServiceNow KnowledgeBase:  
  
* **Title**: KB: List Outlook 2010 articles

* **Prompt**: List the articles regarding Outlook 2010. Show in a table with the article title in one column and a brief summary in the other

![](images/firststarterprompt.png)

c. Add the following one to retrieve the information from ServiceNow Service Catalog:  

* **Title**: Catalog: Hardware

* **Prompt**: How do I request a new laptop?

d. Add the following one that will be used to retrieve the information from a SharePoint site:  

* **Title**: SharePoint: List Incidents 

* **Prompt**: List the items from the snow spreadsheet and format as a table 

e. Add the following one that to get real-time updates on incidents:  

* **Title**: Actions: My incidents 

* **Prompt**: List my incidents 

f. Add the following one to create a new incident on ServiceNow:  

* **Title**: Actions: Create an incident 

* **Prompt**: Please create a new incident for my printer. It is not working, and I need assistance to resolve the issue as soon as possible. Thank you!

g. After adding your starter prompts, click on the **Save** button to save your changes and ensure that the prompts are available for users.

![](images/saveprompts.png)

11. **Create the agent**: Before adding the knowledge to the agent, we need to create the agent first. To do this, click on the **Create** button to create the agent.

![](images/createagent.png)

After clicking on the Create button, there will be a brief waiting period while the agent is being created. During this time, the system is setting up the necessary configurations and preparing the agent for use. Please be patient and wait for the process to complete. Once the agent is successfully created, you will be able to proceed with adding the knowledge sources and configuring the agent as needed.

![](images/waitagentbecreated.png)

So far, we have named our agent, defined an icon and background, provided a description, set some instructions, and created the starter prompts. However, if you try to interact with the agent at this stage, it will not be able to answer any questions. This is because we have instructed our agent not to use the internal language model (LLM) and we have not yet provided any knowledge sources for it to use.

To verify this, go to the "Test Your Agent" panel and click on any starter prompt, such as "KB: List Outlook 2010 articles." You will notice the message: **Sorry, I can't answer your question. Please let me know if I can assist you with anything else.**

![](images/noresults.png)

In the next steps, you will learn how to add knowledge to the agent, ensuring it can respond accurately to user queries based on the specified data sources.



### Consuming ServiceNow Graph Connectors

In this section, we will learn how to add the knowledge mentioned earlier in the instructions. This knowledge will ensure that the agent's responses are based on the declared data sources and not on the internal language model. 

Follow these steps to add the knowledge:

1. Click on **+ Add knowledge**:

![](images/addknowledge.png)

2. Click on **Advanced**:

![](images/addknowledgeadv.png)

3. Click on **ServiceNow Knowledge** graph connector:

![](images/addsnkbconnector.png)

4. Select the first graph connector that is already configured in the [Microsoft Admin Center](https://admin.microsoft.com/#/homepage) and click on the **Add** button to include it in your agent's knowledge base.

![](images/addsnkbconnector2.png)

5. Notice that the ServiceNow Knowledge connector was added in the knowledge base. Now, click again on **+ Add knowledge** to add the ServiceNow Service Catalog connector.

![](images/snkbadded.png)

6. Click on **ServiceNow Catalog** graph connector:

![](images/addsnsc.png)


7. Select the first graph connector that is already configured in the [Microsoft Admin Center](https://admin.microsoft.com/#/homepage) and click on the **Add** button to include it in your agent's knowledge base.

![](images/addsnsc2.png)


After adding the two graph connectors, you should be able to see both ServiceNow graph connectors listed in the agent's knowledge base.

![](images/sngraphconnectors.png)

Now that we have the ServiceNow Knowledge and Service Catalog set up, we can test our agent to see if it is working properly.

8. In the **Test Your Agent** panel, click on the **KB: List Outlook 2010 articles** prompt. 

![](images/outlook2010prompt.png)

Unlike our previous experience, the agent should now list the Outlook 2010 articles in a table format.

![](images/outlook2010result.png)

Observe that we can verify the information is sourced from the ServiceNow Knowledge connector by checking the references used to answer our prompt.

![](images/outlook2010references.png)

9. Now, click on the **Catalog: Hardware** prompt or simply type **How do I request a new laptop?** to verify if the response is sourced from the Service Catalog.


![](images/laptopprompt.png)

Observe that the response came from the Service Catalog as expected.

![](images/laptopreference.png)

### Consuming SharePoint site

In this session, we will explore how to effectively consume data from a SharePoint site. This includes understanding the various methods and tools available for accessing and utilizing SharePoint resources.

#### Introduction to SharePoint
SharePoint is a powerful platform developed by Microsoft for storing, organizing, sharing, and accessing information from any device. It enhances security and efficiency in managing your organization's content. SharePoint is widely used for creating websites, document libraries, and collaborative spaces, making it an essential tool for businesses to streamline workflows and foster collaboration.

#### Benefits

Using SharePoint as a knowledge base for a Copilot Declarative Agent offers several benefits:

1. **Centralized Information**: SharePoint allows you to store all relevant documents, data, and resources in one place, making it easier for the agent to access and retrieve information. By having all relevant documents, data, and resources in one place, the Copilot Declarative Agent can quickly access and retrieve the most accurate and up-to-date information. This reduces the scope of the search, minimizing the chances of retrieving irrelevant or outdated information, and ensures that the responses provided by the agent are precise and reliable. This efficiency not only saves time but also enhances the overall user experience by delivering more accurate answers.

2. **Enhanced Collaboration**: SharePoint's collaborative features enable teams to work together seamlessly, ensuring that the knowledge base is always up-to-date and accurate.

3. **Security and Permissions**: SharePoint provides robust security features, allowing you to control who can access and edit the information, ensuring that sensitive data is protected.

#### Steps to Add SharePoint Knowledge Base

Follow these steps to add the knowledge:

1. Click on **+ Add knowledge** button to start the process of adding a new knowledge base.

![](images/addknowledge2.png)

2. In the list of available knowledge sources, select **SharePoint**.

![](images/addsharepoint.png)

3. Specify the SharePoint site or document library you want to use as the knowledge base. For the purposes of this lab, choose the following SharePoint site: https://m365cpi69113837.sharepoint.com/sites/servicenow and then click on **Add**:


![](images/addsharepoint1.png)

> You can select multiple sites or libraries if needed. After selecting the SharePoint site or document library, it's crucial to provide a comprehensive description with the purpose of the site and key content areas.

4. Modify the **Name** and **Description** for the SharePoint Site:

* **Name**: Update the name of the SharePoint site to clearly reflect its purpose. For example, "ServiceNow Collaboration Site"

* **Description**: Provide a concise and informative description that outlines the key features and purpose of the site. For example, "This SharePoint site serves as a comprehensive resource for ServiceNow, including documentation, knowledge base articles, training materials, project plans, and collaboration spaces."

![](images/addsharepoint2.png)

5. Click on **Add** to finalize the addition of the SharePoint knowledge base to your Copilot Declarative Agent.

![](images/addsharepoint3.png)

6. Look for the name of the SharePoint site you added in the list of knowledge sources. Ensure that it appears correctly with the updated name and description.

![](images/addsharepoint4.png)


Now that we have added the ServiceNow SharePoint site to the agent's knowledge base, it is time to test if the integration is working correctly. Follow these steps to verify the integration:

7. Verify the Presence of the snow.xls file:

https://m365cpi69113837.sharepoint.com/sites/servicenow/Shared%20Documents

![](images/snowfile.png)

8. Switch back to your agent. In the test panel, use the following prompt to retrieve the incident list from the snow.xls file:

```plaintext
List the items from the snow spreadsheet and format as a table.
```


9. Review the agent's response to ensure it lists the items from the snow.xls file and formats them as a table.

![](images/snowfileresult.png)


By following these steps, you can confirm that the integration between the ServiceNow SharePoint site and the agent's knowledge base is working as expected.



### Consuming ServiceNow REST APIs

In this section, you'll learn how to programmatically interact with the ServiceNow platform by consuming its REST APIs. This will enable you to retrieve, update, and create data in ServiceNow, enhancing the functionality of your Declarative Agent.

Please note that we are not directly consuming the ServiceNow REST APIs. Instead, we use an intermediary API developed in C# that handles communication with ServiceNow. This C# API requires authentication to ensure secure access.

ServiceNow offers a robust set of REST APIs that allow you to perform various operations on the platform using standard HTTP methods such as GET, POST, PUT, and DELETE. To consume these APIs, you need to authenticate your requests. ServiceNow supports several authentication methods, including OAuth, Basic Authentication, and API tokens. For security reasons, it is recommended to use OAuth or API tokens instead of hardcoding credentials in your code.

>Note: In this lab, we are not focusing on the development of the server-side APIs for simplicity. These steps have been previously set up, allowing you to concentrate on consuming the APIs and integrating them with your Declarative Agent.

#### Steps to Add an Action

Follow these steps to add an action:

1. Start by clicking the **+ Add Action** button to initiate the process of adding a new action.

![](images/addaction.png)


2. Click on **+ New action** and then select the option **New REST API**.

![](images/newrestapi.png)

3. In the **Add REST API plugin** UI, you will be prompted to upload the REST API specification file of the API you want to consume. Click on the drag and drop area to browse for the OpenAPI file specification.

![](images/dragopenfilespecification.png)

4. Choose the **servicenow_openapi.yaml** available at C:\Labs\\.

5. Once the file is loaded, click on **Next** to proceed.

![](images/addapinext.png)

6. In the API plugin details, you can provide the action name and a description for your action. You don't need to change anything as this information is extracted from the file. Click on **Next** to proceed. 

![](images/addapinext2.png)

7. The next step is to choose the authentication type. Since the REST API we want to consume is protected, select **OAuth 2.0** from the Choose authentication implemented by your API list and click **Next**.

![](images/addapinext3.png)

8. In this step, we need to configure the plugin to Authenticate Users via OAuth.

>Note: To set up OAuth authentication for your plugin using Microsoft's Azure AD. The necessary credentials have been pre-configured in Azure, and you only need to input them into your plugin configuration.

The following values are derived from an Azure application registration that was set up beforehand. You do not need to manage or adjust the Azure application registration for this lab. Your task is simply to input these credentials into your plugin's configuration.

a. Input the Following OAuth Details:

* Client ID: fe9d68e3-3c2c-480d-8ddf-4e99fdfc4564
* Client Secret: 	Iwd8Q~lEo8wnec0fPbpvZAUjGmT82Zjq-y2LYcBw
* Authorization URL: https://login.microsoftonline.com/b5d31b4e-6d83-4373-b61b-de1b0cd6f140/oauth2/v2.0/authorize
* Token URL: https://login.microsoftonline.com/b5d31b4e-6d83-4373-b61b-de1b0cd6f140/oauth2/v2.0/token
* Refresh URL: https://login.microsoftonline.com/b5d31b4e-6d83-4373-b61b-de1b0cd6f140/oauth2/v2.0/token
* Scope: api://9fb937e3-6dcf-4b2f-91d5-31cc8cb48f6b/access_as_user

b. Click on **Next**.

![](images/addapinext4.png)


9. Now we need to select the actions, functions of the API, that we want to make available to the agent. Click on the first one, the **Retrieve ServiceNow incidents**:

![](images/addapinext5.png)

10. Click **Next**. Be aware that the action name and description might already be filled in if sourced from the OpenAI specification file, but not all files will have this information. Here, you get to refine or add more detail to each action's description, which is essential for teaching the agent about available resources and what to search for, thus optimizing its interaction with the system.

![](images/addapinext6.png)

11. Click **Next**. Here, you have a chance to review and enrich the details of the parameters and expected results for your function. This step is vital as it helps the agent accurately identify and handle the expected information, ensuring better interaction and performance.

![](images/addapinext7.png)
  
12. Click on the second one, the **Create a new incident**, to make it available for our agent:

![](images/addapinext8.png)

13. Click **Next** as the information is already filled.

![](images/addapinext9.png)

14. Take time to review the input and output values and update descriptions as needed. Click on **Next**

![](images/addapinext10.png)

15. Click **Next**. On the "Select Actions" page, you'll see a list of actions you've chosen for your plugin. Ensure all actions are selected before proceeding.

![](images/addapinext11.png)

16. Before moving forward, ensure that exactly two actions are are listed under "Selected actions." Once confirmed, click **Next** to continue.

![](images/addapinext12.png)

This action will initiate the publishing process for your plugin configuration. Please note that publishing might take a moment, so allow some time for the system to complete this operation.

![](images/addapinext13.png)

17. Once your action has been published, click **Create connection** to finish.

![](images/addapinext14.png)

#### Steps to add the action to get the incidents

1. The next step involves adding the actions we have previously created. To do this, **search for ServiceNow** in the action list. Once you find it, **select the action** that allows you to list the ServiceNow incidents. 

![](images/addapinext15.png)

2. Click on the **Sign in** button to configure the connection. You will be prompted to sign in with the account XX@XX. 

![](images/addapinext16.png)

3. Ensure that the connection is active. Once you have verified that the connection is successful, click on the **Next** button to proceed.

![](images/addapinext20.png)

4. Review the action's settings, including the available options, inputs, and outputs. Ensure that everything is configured correctly according to your requirements. Once you have verified all the details, click on the **Add action** button to proceed

![](images/addapinext21.png)

5. You should now see the action to retrieve the list of incidents in the Action list. Verify that this action is present and correctly configured. 

![](images/actionslist.png)

#### Steps to test the action to get the incidents

1. To test the 'Get Incidents' action, click on the icon **restart** to start a new conversation. Now, you can either click on the item **Actions: My incidents** or just type **list my incidents** to retrieve the list of incidents.

![](images/testincidents1.png)

2. Since this is your first time accessing the action, you will need to grant the necessary permissions for the agent to use it. When prompted, click on **Connect** to authorize the connection.

![](images/testincidents2connect.png)

3. On the "Manage Your Connections" page, click on **Connect** to configure the connection settings. You will be prompted to sign in with the account XX@XX. 

![](images/testincidents3.png)

4. Verify that the connection was successful, and then click on **Submit** to finalize the configuration.

![](images/testincidents4.png)

5. Ensure that the connection status shows as **Connected**.

![](images/testincidents5.png)

6.  Switch back to the Copilot Studio page and click on **Retry** to list the incidents.

>Note: If it doesn't work, start a new conversation.

![](images/testincidents2retry.png)

7. The agent is expected to display all incidents that are currently open for the user.

![](images/testincidents6.png)  
  
#### Steps to add the action to create a new incident

In the previous session, you learned how to add the action to list the incidents. Now, it is time to add a session to create a new incident. This exercise will demonstrate how actions, unlike graph connectors, allow us not only to retrieve information from external apps but also to send information to them. By creating a new incident, you will see how to interact with the ServiceNow platform in a more dynamic and functional way.

1. Begin by clicking the **+ Add Action** button to start the process of adding a new action.

![](images/addaction.png)

2. In the search box, type **ServiceNow** and press Enter. From the search results, select the action **Create a new incident**. This action will enable you to create a new incident within the ServiceNow platform.

![](images/newincident1.png)


3. Once you have verified that the connection is successful, click on the **Next** button to proceed.

>Note: The connection should already be active since it was set up for the previous action. If it is not, click on the Sign in button to configure the connection. You will be prompted to sign in with your account credentials.

![](images/newincident2.png)

4. Review the action's settings, including the available options, inputs, and outputs. Make sure everything is configured correctly according to your requirements. Once you have verified all the details, click on the **Add action** button to proceed.

![](images/newincident3.png)

5. Wait for the action to be added. This process might take a few seconds, so please be patient.

![](images/newincident4.png)

6. You should now see the action to create a new incident in the Action list. Verify that this action is present and correctly configured.

#### Steps to test the action to create a new incident

1. To test the 'Create a New Incident' action, click on the **restart icon** to start a new conversation. Now, click on the item **Actions: Create an incident** to create a new incident.

![](images/testnewincident1.png)

2. Just like with the previous action, since this is your first time accessing the new action, you will need to grant the necessary permissions for the agent to use it. Click on **Connect** to authorize the connection.

![](images/testnewincident2.png)

3. On the "Manage Your Connections" page, click on **Connect** to configure the connection settings.

![](images/testnewincident3.png)

4. The connection is supposed to be already set, since you already configure it for the previous action. In case it is not connected, please sign in with the account XX@XX. Click on **Submit** to finalize the configuration.

![](images/testnewincident4.png)

5. Ensure that the connection status shows as **Connected**.

![](images/testnewincident5.png)

6.  Switch back to the Copilot Studio page and click on **Retry** to list the incidents.

>Note: If it doesn't work, start a new conversation.

![](images/testnewincident6.png)

7. After completing the previous steps, you should see a confirmation message indicating that your ticket was successfully created in ServiceNow. This message confirms that the action to create a new incident has been executed correctly.

![](images/testnewincident7.png)

8. To verify that your ticket was successfully created, you can ask the agent to list your incidents. This will allow you to double-check and ensure that the new incident appears in the list of your tickets.

![](images/testnewincident8.png)

### Demonstrating Complex Prompts

Now that the agent has both knowledge and actions defined, you can use complex prompts that combine multiple actions and knowledge retrieval. For instance, you might need to find a specific spreadsheet in SharePoint, retrieve details about a system crash incident, and create a new incident in ServiceNow.

Notice that we need to run the following three steps.

* List the items from the snow spreadsheet
* Get the item About System Crash
* Create a New Incident in ServiceNow


While you could run these prompts individually, integrating them into a single prompt can streamline your workflow and make the process more natural.


1. For example, you can use the following prompt: 

Find the SNOW spreadsheet in SharePoint, get the item about system crash, and create a new incident on ServiceNow.

![](images/complex3.png)

2. Use the following prompt to list the incidents on ServiceNow and double-check if the incident was created as expected: "List my incidents on ServiceNow." This will allow you to verify that the new incident appears in the list of your tickets.

![](images/complex4.png)

By following these steps, you can efficiently handle complex tasks that involve multiple actions and knowledge retrieval, demonstrating the powerful capabilities of integrating various functionalities.


### Setting Up Email Communication

In this session, you will learn how to set up email communication using the **Office 365 Outlook** connector available in the actions. Connectors allow you to integrate various external applications and services, enabling seamless communication and data exchange.

#### Introduction to Connectors:

Connectors are powerful tools that enable you to connect different applications and services, allowing them to work together seamlessly. By using connectors, you can automate tasks, streamline workflows, and enhance productivity. In this session, we will focus on using the Outlook connector to set up email communication.

#### Steps to Set Up Email Communication:


1. Start by clicking on the + Add Action button available in the actions section of the agent.

![](images/addaction.png)

2. Search for Office and click the action **Send an email (V2)**.

![](images/addaction2.png)

3. If a connection is already set, click on **Next** to proceed. Otherwise, click on the **'...'** button to configure the connection. You will be prompted to sign in with your Outlook account credentials. Ensure that the connection is active and successfully configured.

![](images/addaction3.png)

4. Click on the **Add action** button.

![](images/addaction4.png)

5. Please wait a few seconds for the action to complete.

![](images/addaction5.png)

6. Make sure that Office 365 Outlook appears in the actions list.

![](images/addaction6.png)

#### Updating Agent Instructions for Email:

To ensure our agent sends emails in the correct format, we need to update the instructions. Specifically, we need to include a step that instructs the agent to send all emails in rich text format. Additionally, if the email address domain is not specified and only the user alias is provided, the agent should assume the domain is @M365CPI69113837.onmicrosoft.com.

1. In the Agent's Details section, click on the **Edit** button to modify the instructions.

![](images/updateinstructions1.png)

Add the following instructions at the end of the agent instructions:

```plaintext
7. **Emails instructions:**
 a. Always ask the user to confirm before sending the email. Do not send it without user confirmation.
 b. Use rich text format in the email body.
 c. If the user provides only the recipient's alias, append the domain @M365CPI69113837.onmicrosoft.com to the alias. 
d. When drafting an email, if the recipient's email address is not fully specified (i.e., only the alias is provided), automatically append the domain @M365CPI69113837.onmicrosoft.com to the alias.
 e. Before asking for the email recipient, double-check if the email address is already provided in the chat history in the previous messages. 
f. If all the above rules are satisfied, use the Office 365 Outlook connector to send the email.
```

2. Click on the **Save** button to update the agent with the email instructions.

![](images/updateinstructions2.png)

#### Testing the connector

After setting up the email details, you can test the action to ensure it works correctly.

1. In the "Test your agent" panel, click the **Restart** button to begin a new conversation.

![](images/testoutlook1.png)

2. Click on **List my incidents**.

![](images/testoutlook2.png)

3. Ask the agent to **Help me draft an email to amberr asking her to review the incidents list.**. Since this is the first time using the connector, you will be prompted to connect. Click on **Connect** to allow the connector to be used.

![](images/testoutlook3.png)

4. On the "Manage Your Connections" page, find the Office 365 Outlook connection and click on **Connect** to configure the connection settings.

![](images/testoutlook4.png)

4. The connection is supposed to be already set, since you already configure it for the previous actions. In case it is not connected, please sign in with the account XX@XX. Click on **Submit** to finalize the configuration.

![](images/testoutlook5.png)

5. Ensure that the connection status shows as **Connected**.

![](images/testoutlook6.png)

6.  Switch back to the Copilot Studio page and click on **Retry** to list the incidents.

>Note: If it doesn't work, start a new conversation.

![](images/testoutlook7.png)

7. The agent is expected to draft an email to Amber with the incidents listed in a table format. Feel free to ask the agent to make any changes to the message with your preferences.

![](images/testoutlook8.png)

8. Instruct the agent to list the incidents in a table format:

```plaintext
please use the table format to show the incidents
```

![](images/testoutlook9.png)

8. If everything looks good, ask the agent to send the email.

```plaintex
It looks good. Please send the email to her using rich text format.
```
![](images/testoutlook9.png)

By following these steps, you can set up email communication using the Outlook connector, enabling seamless integration with your Outlook account and automating your email workflows.


### Publish the agent

