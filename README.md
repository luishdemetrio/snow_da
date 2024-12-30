# Learn how to build a Declarative Agent via Copilot Studio to consume ServiceNow Graph Connectors and REST APIs


In this hands-on lab, you will dive into the world of automation and integration by using Copilot Studio to create a Declarative Agent tailored for ServiceNow interactions. Here's what you'll learn:

* **Building a Declarative Agent in Copilot Studio:** Understand the fundamentals of setting up and configuring a Declarative Agent specifically designed to interact seamlessly with ServiceNow.

* **Leveraging ServiceNow Graph Connectors:** You'll explore how to integrate your agent with ServiceNow's KnowledgeBase and Catalog connectors. This will enable your agent to fetch and manage knowledge articles and service catalog items directly from ServiceNow, enhancing its capability to provide precise, context-aware responses or actions.

* **Consuming ServiceNow REST APIs with Actions:** Gain hands-on experience in using Actions within Copilot Studio to interact with ServiceNow's REST APIs. This includes learning how to make authenticated API calls to retrieve, update, or create data in ServiceNow, thus extending the functionality of your Declarative Agent.

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

When working with declarative agents, we need to explicitly define what resources we want to use through graph connectors and actions. This approach ensures that the agents are tailored to specific tasks and domains, making them highly specialized and effective. By creating a declarative agent, we don't have access to the full semantic index but just to the parts accessed via the graph connectors that were defined. This is because declarative agents are designed to be specialists, focusing on specific tasks or domains. This allows the agent to access relevant enterprise data and improve its responses. Additionally, we can provide real-time information to the agent via actions or even through Internet web searches. This ensures the agent stays updated and relevant, delivering accurate and timely responses based on the most current data available.

![](images/copilotstudiokanda.png)

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

4. In the **Agents** section, select **+Add**

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
 
 e. After making these changes, click "Save" to apply the new icon and background color.

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

To verify this, go to the "Test Your Agent" panel and click on any starter prompt, such as "KB: List Outlook 2010 articles." You will notice the message: "Sorry, I can't answer your question. Please let me know if I can assist you with anything else."

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

### Consuming ServiceNow REST APIs

ServiceNow REST APIs:
Access and use data from ServiceNow REST APIs to provide accurate and relevant information.
Configure the agent to interact with the necessary ServiceNow REST APIs.
SharePoint Site:

Refer to the SharePoint site (to be defined later) for additional information and resources.
Make sure the agent can access and retrieve information from the specified SharePoint site.
By adhering to these instructions, the agent ensures that all responses are based on the declared data sources and not on the internal language model.

* ServiceNow Graph Connectors: Utilize the information available through ServiceNow Graph Connectors to respond to user queries.

* ServiceNow REST APIs: Access and use data from ServiceNow REST APIs to provide accurate and relevant information.

* SharePoint Site: Refer to the SharePoint site (to be defined later) for additional information and resources.
By adhering to these instructions, the agent ensures that all responses are based on the declared data sources and not on the internal language model.
