# Readme for Git smudge and clean filter spike

[[_TOC_]]

---

## Necessary Assets

- two bash files with commands to replace placeholder with IP address and vice versa based on **sed**
  - `./scripts/smudge.sh`  
    replaces the placeholder with IP address
  - `./scripts/clean.sh`  
    replaces the IP address with placeholder
- configuration entries to define these bash files as filter
- filter definition for specific filetypes in `.gitattributes`

---

## Details

### Smudge filter

Currently these Bash files with the filters are located in subfolder `./scripts/`. This is only for demonstration purposes. Because the filter needs to get adjusted for the individual environment, Git will then always see these changes.

One solution might be to copy these files to a non-tracked location, e.g. the folder `./.git`.

 in `smudge.sh`

```bash
#!/bin/sh
sed -e 's/asset-ip/172.30.12.52/'
```

For further details see also the **sed** documentation.

### Publish the filters

The publishing of a filter (e.g. with name `replace-ip` needs to be done via Git configuration.

Configure via direct editing of the config file

1. Open with an editor the file `.git/config`
1. Paste this fragment and adjust it

   ```text
   [filter "replace-ip"]
       smudge = C:/_projects/_azure/Sandbox-Marko/05.git-filters/scripts/smudge.sh
       clean = C:/_projects/_azure/Sandbox-Marko/05.git-filters/scripts/clean.sh
   ```

Configure via Git CLI commands

1. Execute the following commands

   ```text
   git config --local filter.replace-ip.smudge /c/_projects/_azure/Sandbox-Marko/05.git-filters/smudge.sh
   git config --local filter.replace-ip.clean /c/_projects/_azure/Sandbox-Marko/05.git-filters/clean.sh
   ```

### Activate the filter

> **Remark:** Some web references describe the usage of Git smudge and clean filter without this step. It was not possible for me to get it run without.

The filter needs to get activated for the desired files.

1. Create a `.gitattributes` file on the highest wanted folder  
   (to recursively apply this filter for all folders below)
1. Define for which files the filter should run

   ```text
   *.json text eol=lf filter=replace-ip
   ```

---

## Resources

- [Protect secrets in Git with the clean/smudge filter](https://developers.redhat.com/articles/2022/02/02/protect-secrets-git-cleansmudge-filter#)
- [Git Smudge and Clean Filters: Making Changes So You Don’t Have To](https://bignerdranch.com/blog/git-smudge-and-clean-filters-making-changes-so-you-dont-have-to/)
- #374969
