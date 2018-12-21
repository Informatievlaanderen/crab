# Versioning approach

## Git Commit Guidelines

We have very precise rules over how our git commit messages can be formatted.  This leads to **more
readable messages** that are easy to follow when looking through the **project history**.  But also,
we use the git commit messages to **generate the change log**.

The commit message formatting can be added using a typical git workflow or through the use of a CLI
wizard ([Commitizen](https://github.com/commitizen/cz-cli)). To use the wizard, run `yarn run commit`
in your terminal after staging your changes in git.

### Commit Message Format
Each commit message consists of a **header**, a **body** and a **footer**.  The header has a special
format that includes a **type**, a **scope** and a **subject**:

```
<type>(<scope>): <subject>
<BLANK LINE>
<body>
<BLANK LINE>
<footer>
```

The **header** is mandatory and the **scope** of the header is optional.

Any line of the commit message cannot be longer 100 characters! This allows the message to be easier
to read in various git tools.

### Revert
If the commit reverts a previous commit, it should begin with `revert: `, followed by the header
of the reverted commit.
In the body it should say: `This reverts commit <hash>.`, where the hash is the SHA of the commit
being reverted.
A commit with this format is automatically created by the [`git revert`][git-revert] command.

### Type
Must be one of the following:

* **feat**: A new feature
* **fix**: A bug fix
* **docs**: Documentation only changes
* **style**: Changes that do not affect the meaning of the code (white-space, formatting, missing semi-colons, etc)
* **refactor**: A code change that neither fixes a bug nor adds a feature
* **perf**: A code change that improves performance
* **test**: Adding missing or correcting existing tests
* **build**: Changes that affect the build system or external dependencies (example scopes: gulp, broccoli, npm)
* **ci**: Changes to our CI configuration files and scripts (example scopes: Travis, Circle, BrowserStack, SauceLabs)
* **chore**: Changes to the build process or auxiliary tools and libraries such as documentation generation
* **revert**: Reverts a previous commit

### Scope
The scope could be anything specifying place of the commit change. For example `core`,
`README`, `ui`, etc...

You can use `*` when the change affects more than a single scope.

### Subject
The subject contains succinct description of the change:

* use the imperative, present tense: "change" not "changed" nor "changes"
* don't capitalize first letter
* no dot (.) at the end

### Body
Just as in the **subject**, use the imperative, present tense: "change" not "changed" nor "changes".
The body should include the motivation for the change and contrast this with previous behavior.

### Footer
The footer should contain any information about **Breaking Changes** and is also the place to
[reference Jira issues that this commit closes][https://confluence.atlassian.com/bitbucket/processing-jira-software-issues-with-smart-commit-messages-298979931.html].

**Breaking Changes** should start with the word `BREAKING CHANGE:` with a space or two newlines.
The rest of the commit message is then used for this.

A detailed explanation can be found in this [document][https://docs.google.com/document/d/1FL1N2tXY3B7rKAYEsson8cmERao5x73Z4aaSsrhjpFI/edit?usp=sharing].

## Semantic version configuration

### verifyConditions

#### @semantic-release/changelog

Verify the `changelogFile` option configuration.

#### @semantic-release/git

Verify the access to the remote Git repository, the commit `message` format and the `assets` option configuration.

### analyzeCommits

#### @semantic-release/commit-analyzer

We use the format described in [Angular convention](https://github.com/conventional-changelog/conventional-changelog/blob/master/packages/conventional-changelog-angular) with some extra rule matches:

- Commits with `type` 'docs' and `scope` 'README' will be associated with a `patch` release.
- Commits with `type` 'refactor' and `scope` starting with 'core' (i.e. 'core-ui', 'core-rules', ...) will be associated with a `minor` release.
- Other commits with `type` 'refactor' (without `scope` or with a `scope` not matching the regexp `/core.*/`) will be associated with a `patch` release.

If a commit doesn't match any rule the default release rules will apply:

- Commits with a breaking change will be associated with a `major` release.
- Commits with `type` 'feat' will be associated with a `minor` release.
- Commits with `type` 'fix' will be associated with a `patch` release.
- Commits with `type` 'perf' will be associated with a `patch` release.

If a commit doesn't match any rules then no release type will be associated with the commit.

- Commits with `type` 'style' will not be associated with a release type.
- Commits with `type` 'test' will not be associated with a release type.
- Commits with `type` 'chore' will not be associated with a release type.

Commits with a `BREAKING CHANGE`, `BREAKING CHANGES` or `BREAKING` section in the commit body will be seen as a `major` release.

### verifyRelease

### generateNotes

#### @semantic-release/release-notes-generator

We use the format described in [Angular convention](https://github.com/conventional-changelog/conventional-changelog/blob/master/packages/conventional-changelog-angular) with some extra rule matches:

Commits with a `BREAKING CHANGE`, `BREAKING CHANGES` or `BREAKING` section in the commit body will be seen as a `major` release.

### prepare

#### @semantic-release/changelog

Create or update the changelog file in the local project repository.

Creates a file called `CHANGELOG.md` to include in the release.

#### @semantic-release/npm

Update the `package.json` version.

#### @semantic-release/git

Create a release commit, including configurable files.

Be sure to set `GIT_USERNAME` and `GIT_EMAIL`

| Variable          | Description                                                                                                                                 |
| ----------------- | ------------------------------------------------------------------------------------------------------------------------------------------- |
| `GIT_USERNAME`    | [Git username](https://git-scm.com/book/en/v2/Getting-Started-First-Time-Git-Setup#_your_identity) associated with the release commit.      |
| `GIT_EMAIL`       | [Git email address](https://git-scm.com/book/en/v2/Getting-Started-First-Time-Git-Setup#_your_identity) associated with the release commit. |

Configured to include `CHANGELOG.md`, `package.json` and `package-lock.json`.

### publish

### success

### fail
